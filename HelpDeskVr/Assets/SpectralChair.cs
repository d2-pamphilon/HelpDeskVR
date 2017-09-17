using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralChair : MonoBehaviour {

    public Transform[] positions;
    public int curentPos;

    public float timer = 0.0f;
    public float timeBetweenMovement = 1.0f;

	// Use this for initialization
	void Start () {
        curentPos = 0;
        timeBetweenMovement = Random.Range(7.0f, 46.0f);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > timeBetweenMovement)
        {
            timer = 0.0f;
            curentPos = Random.Range(0, positions.Length);
        }

        transform.position = Vector3.Lerp(transform.position, positions[curentPos].position, 0.04f);
        transform.rotation = Quaternion.Lerp(transform.rotation, positions[curentPos].rotation, 0.04f);

    }
}
