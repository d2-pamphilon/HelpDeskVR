using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LaptopDimension
{
    public GameObject Laptop;
    public GameObject Dimension;
}

public class GameManager : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        createdDimensions = new Dictionary<GameObject, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        foreach (KeyValuePair<GameObject, GameObject> entry in createdDimensions)
        {
            if (entry.Value.GetComponent<DimensionTimer>().timeOver)
            {
                DestroyLaptop(entry.Key);
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
}
