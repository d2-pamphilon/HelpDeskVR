using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

    public float speed = 1;
	
	// Update is called once per frame
	void Update () {
        transform.position += (Vector3.left * speed); ;
        Destroy(gameObject, 10f);
	}
}
