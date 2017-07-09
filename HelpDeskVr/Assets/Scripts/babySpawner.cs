using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Head;

    [SerializeField]
    private GameObject[] SpawnLocations;

    [SerializedFeild]
    private GameObject ParentObj;
    

    float timer;
    int counter;

    void Start()
    {
        timer = 0;
        counter = 0;
    }


    void Update()
    {
        if (counter < 25)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                //efficent, place location in random order in list
                Instantiate(Head, SpawnLocations[counter].transform.position, SpawnLocations[counter].transform.rotation, ParentObj);
                counter++;
                timer = 0;
            }
        }
    }
}
