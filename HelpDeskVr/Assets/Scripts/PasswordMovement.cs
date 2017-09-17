using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordMovement : MonoBehaviour {

    public Vector3 target;
    public Transform centerPoint;
    private float speed = 1.0f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Vector3 tmp =  (new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)));
        tmp.Normalize();
        rb.velocity = tmp;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < 0.01f)
        {
            var ls = transform.localScale;
            ls.x += transform.localScale.x * 0.1f;
            ls.y += transform.localScale.y * 0.1f;
        }
        //GetComponent<Rigidbody>().AddForce(new Vector3(Random.value/100.0f, Random.value / 100.0f, Random.value / 100.0f));
        //Vector3 heading = centerPoint.position - transform.position;
        //transform.LookAt(transform.position - (GameManager.Instance.mainCamera.transform.position - transform.position));
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 tmp = (new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)));
        tmp.Normalize();
        rb.velocity = tmp;
    }
}
