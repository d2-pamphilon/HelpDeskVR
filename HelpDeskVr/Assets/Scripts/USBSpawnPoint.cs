using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USBSpawnPoint : MonoBehaviour {

    public bool USBpresent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay (Collider other)
    {
        if (other.tag == "USB")
        {
            USBpresent = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "USB")
        {
            USBpresent = false;
        }
    }
}
