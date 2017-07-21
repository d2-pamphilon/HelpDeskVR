using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour {
	[SerializeField]
	private float speed;
	[SerializeField]
	private Vector3 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (direction, speed * Time.deltaTime);
	}
}
