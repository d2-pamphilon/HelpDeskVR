using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBSpawner : MonoBehaviour {

    [Tooltip("Possible good USBs")]
    [SerializeField]
    GameObject[] goodUSBs;

    [Tooltip("Possible bad USBs")]
    [SerializeField]
    GameObject[] badUSBs;

    GameObject[] RandomSpawnPoints;

    //[Tooltip("Place where the good USBs spawn")]
    //[SerializeField]
    //GameObject GoodUsbSpawn;

	// Use this for initialization
	void Start () {
        RandomSpawnPoints = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            RandomSpawnPoints[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!(RandomSpawnPoints[i].GetComponent<USBSpawnPoint>().USBpresent))
            {
                if (!PlayerLooking.IsPlayerLookingAt(RandomSpawnPoints[i]))
                {
                    if (Random.value < 0.5f)
                    {
                        GameObject USB = Instantiate(goodUSBs[Random.Range(0, goodUSBs.Length)]);
                        USB.transform.position = RandomSpawnPoints[i].transform.position;
                        DimensionChanger.SetLayerRecursively(USB, GameManager.Instance.mainDimension.layer);
                    }
                    else
                    {
                        GameObject USB = Instantiate(badUSBs[Random.Range(0, badUSBs.Length)]);
                        USB.transform.position = RandomSpawnPoints[i].transform.position;
                        DimensionChanger.SetLayerRecursively(USB, GameManager.Instance.mainDimension.layer);
                    }
                }
            }
        }
    }

    
}
