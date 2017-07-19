using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LaptopDimension
{
    public GameObject Laptop;
    public GameObject Dimension;
    public USB_PROGRAM fix;
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    [Header("Laptop Spawning Settings", order = 0)]
    [Space(10, order = 1)]

    [SerializeField]
    public float minimumFramesForSpawningLaptop = 120.0f;

    [SerializeField]
    float baseLaptopSpawnTime = 30.0f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float difficultyDecreaseForFailedLaptop = 0.3f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float difficultyIncreaseForFixedLaptop = 0.3f;

    //Laptop Spawning
    [Range(1.0f, 4.0f)]
    public float difficulty = 1.0f;
    float timeUntilNextSpawn = 60.0f;
    float laptopTimer = 0.0f;


    [Header("GameManager needed Links", order = 2)]
    [Space(10, order = 3)]

    [SerializeField]
    public GameObject mainDimension;
    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    GameObject cameraRig;
    [SerializeField]
    Transform laptopSpawnPoint;
    [SerializeField]
    Transform dimensionSpawnPoint;
    [SerializeField]
    public LaptopDimension[] laptopsPrefabs;
    [SerializeField]
    public ScoreTracker scoreTracker;

    [SerializeField]
    Display7SegTimeSetter timerDisplay;
    [SerializeField]
    ContainerDisplay7Seg LaptopsFixedDisplay;
    [SerializeField]
    ContainerDisplay7Seg LaptopsFailedDisplay;


    public Dictionary<GameObject, GameObject> createdDimensions;


    [Header("FPS counting settings", order = 4)]
    [Space(10, order = 5)]
    [Range(0.1f, 1.0f)]
    public float m_refreshTime = 0.5f;

    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;

   

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        createdDimensions = new Dictionary<GameObject, GameObject>();
        scoreTracker = new ScoreTracker();
    }
	
	// Update is called once per frame
	void Update () {

        LaptopsFailedDisplay.text = scoreTracker.currentScore.laptopsFailed.ToString("000");
        LaptopsFixedDisplay.text = scoreTracker.currentScore.laptopsFixed.ToString("000");
        float timeOutOf500 = (mainDimension.GetComponent<DimensionTimer>().elapsedTime / mainDimension.GetComponent<DimensionTimer>().maxTime) * 500.0f;
        timerDisplay.Hours = ((int)(timeOutOf500 + 1000)) / 100;
        timerDisplay.Minutes = (int)((((timeOutOf500) % 100) / 99) * 59);

        if (mainDimension.GetComponent<DimensionTimer>().timeOver)
        {
            scoreTracker.saveData();
            Application.LoadLevel(2);
            Destroy(this.gameObject);
        }

        //Get FPS to make sure not spawning too manny dimensions
        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }

        //Delete finished dimensions;
        foreach (KeyValuePair<GameObject, GameObject> entry in createdDimensions)
        {
            if (entry.Value.GetComponent<DimensionTimer>().timeOver)
            {
                GameObject tempLap = entry.Key;
                GameObject tempDim = entry.Value;
                DestroyLaptop(tempLap);
                LayerManager.instance.RemoveLayer(tempDim.GetComponent<Dimension>().layer);
                difficulty = Mathf.Max(1.0f, difficulty - difficultyDecreaseForFailedLaptop);
                break;
            }
        }

        //Laptop spawning code
        timeUntilNextSpawn = baseLaptopSpawnTime / difficulty;

        laptopTimer += Time.deltaTime;
        if (laptopTimer > timeUntilNextSpawn && m_lastFramerate > minimumFramesForSpawningLaptop)
        {
            laptopTimer = 0.0f;
            SpawnLaptop(Random.Range(0, 4));
        }
        if (createdDimensions.Count == 0)
        {
            laptopTimer = 0.0f;
            SpawnLaptop(Random.Range(0, 4));
        }



        //Laptop spawning cheat codes
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnLaptop(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnLaptop(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnLaptop(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnLaptop(3);
        }

    }

    public void SpawnLaptop(int index)
    {
        GameObject laptop = Instantiate(laptopsPrefabs[index].Laptop);
        DimensionChanger.SetLayerRecursively(laptop, mainDimension.layer);
        GameObject dim = Instantiate(laptopsPrefabs[index].Dimension);
        laptop.GetComponent<Laptop>().correctSolution = laptopsPrefabs[index].fix;

        laptop.transform.position = laptopSpawnPoint.transform.position;
        dim.transform.position = dimensionSpawnPoint.transform.position;
        //Link Laptop portal to dimension;
        LaptopPortal portal = laptop.GetComponentInChildren<LaptopPortal>();
        portal.dimension1 = mainDimension.GetComponent<Dimension>();
        portal.dimension2 = dim.GetComponent<Dimension>();
        portal.mainCamera = mainCamera;
        laptop.GetComponent<Laptop>().connectedDimension = dim;
        laptop.GetComponent<Laptop>().dimTimer = dim.GetComponent<DimensionTimer>();

        laptop.transform.parent = mainDimension.transform;
        portal.dimensionChanging.Add(cameraRig);
        portal.dimensionChanging.Add(laptop);


        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light l in lights)
        {
            l.enabled = l.gameObject.layer == cameraRig.layer;
        }

        AudioSource[] sounds = FindObjectsOfType<AudioSource>();
        foreach (AudioSource s in sounds)
        {
            s.enabled = s.gameObject.layer == cameraRig.layer;
        }

        ParticleSystem[] particle = FindObjectsOfType<ParticleSystem>();
        foreach (ParticleSystem p in particle)
        {
            p.enableEmission = p.gameObject.layer == cameraRig.layer;
        }

        createdDimensions.Add(laptop, dim);
    }

    public void DestroyLaptop(GameObject Laptop)
    {
        if (cameraRig.layer == createdDimensions[Laptop].GetComponent<Dimension>().layer)
        {
            DimensionChanger.SwitchDimensions(cameraRig, createdDimensions[Laptop].GetComponent<Dimension>(), mainDimension.GetComponent<Dimension>());
            DimensionChanger.SwitchCameraRender(mainCamera, createdDimensions[Laptop].GetComponent<Dimension>().layer, mainDimension.GetComponent<Dimension>().layer, null);
        }
        if (Laptop.layer == createdDimensions[Laptop].GetComponent<Dimension>().layer)
        {
            DimensionChanger.SwitchDimensions(Laptop, createdDimensions[Laptop].GetComponent<Dimension>(), mainDimension.GetComponent<Dimension>());
        }
        Destroy(createdDimensions[Laptop]);
        Laptop.GetComponent<Laptop>().selfDestruct();
    }

    public void DestroyDimension(GameObject Laptop)
    {
        if (cameraRig.layer == createdDimensions[Laptop].GetComponent<Dimension>().layer)
        {
            DimensionChanger.SwitchDimensions(cameraRig, createdDimensions[Laptop].GetComponent<Dimension>(), mainDimension.GetComponent<Dimension>());
            DimensionChanger.SwitchCameraRender(mainCamera, createdDimensions[Laptop].GetComponent<Dimension>().layer, mainDimension.GetComponent<Dimension>().layer, null);
        }
        if (Laptop.layer == createdDimensions[Laptop].GetComponent<Dimension>().layer)
        {
            DimensionChanger.SwitchDimensions(Laptop, createdDimensions[Laptop].GetComponent<Dimension>(), mainDimension.GetComponent<Dimension>());
        }
        Destroy(createdDimensions[Laptop]);
        createdDimensions.Remove(Laptop);
        //scoreTracker.currentScore.laptopsFixed++;
        difficulty = Mathf.Min(4.0f, difficulty + difficultyIncreaseForFixedLaptop);
    }
}
