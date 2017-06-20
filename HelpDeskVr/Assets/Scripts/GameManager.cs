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
    Transform laptopSpawnPoint;

    [SerializeField]
    Transform dimensionSpawnPoint;

    [SerializeField]
    public LaptopDimension[] laptopsPrefabs;

    protected Dictionary<GameObject, GameObject> createdDimensions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnLaptop(int index)
    {
        GameObject laptop = Instantiate(laptopsPrefabs[index].Laptop);
        GameObject dim = Instantiate(laptopsPrefabs[index].Dimension);
        //Link Laptop postal to dimension;
        //??? Link dimension portal to laptop ???
        createdDimensions.Add(laptop, dim);
    }

    public void DestroyLaptop(GameObject Laptop)
    {
        Destroy(createdDimensions[Laptop]);
        Destroy(Laptop);
    }
}
