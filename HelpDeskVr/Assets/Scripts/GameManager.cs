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
    [SerializeField]
    GameObject mainDimension;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject cameraRig;
    [SerializeField]
    Transform laptopSpawnPoint;
    [SerializeField]
    Transform dimensionSpawnPoint;
    [SerializeField]
    public LaptopDimension[] laptopsPrefabs;

    protected Dictionary<GameObject, GameObject> createdDimensions;

    public ScoreTracker scoreTracker;

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

        foreach (KeyValuePair<GameObject, GameObject> entry in createdDimensions)
        {
            if (entry.Value.GetComponent<DimensionTimer>().timeOver)
            {
                DestroyLaptop(entry.Key);
                LayerManager.instance.RemoveLayer(entry.Value.GetComponent<Dimension>().layer);
                createdDimensions.Remove(entry.Key);
            }
        }



        //Laptop spawning codes
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
    }

    public void SpawnLaptop(int index)
    {
        GameObject laptop = Instantiate(laptopsPrefabs[index].Laptop);
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
        }
        if (Laptop.layer == createdDimensions[Laptop].GetComponent<Dimension>().layer)
        {
            DimensionChanger.SwitchDimensions(Laptop, createdDimensions[Laptop].GetComponent<Dimension>(), mainDimension.GetComponent<Dimension>());
        }
        Destroy(createdDimensions[Laptop]);
        scoreTracker.currentScore.laptopsFixed++;
    }
}
