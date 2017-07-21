using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour {


    [SerializeField]
    string TagIgnored;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag != TagIgnored)
        {
            var colliders = GetComponents<Collider>();
            foreach (Collider coll in colliders)
            {
                if (!coll.isTrigger)
                {
                    coll.enabled = false;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != TagIgnored)
        {
            var colliders = GetComponents<Collider>();
            foreach (Collider coll in colliders)
            {
                if (!coll.isTrigger)
                {
                    coll.enabled = true;
                }
            }
        }
    }
}
