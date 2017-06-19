using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordMovement : MonoBehaviour {

    public Vector3 target;
    public Transform centerPoint;
    private float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        //Vector3 heading = centerPoint.position - transform.position;
        transform.LookAt(transform.position - (centerPoint.position - transform.position));
	}
}
