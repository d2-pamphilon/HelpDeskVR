using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractSceneController : MonoBehaviour {

    public GameObject camera;
    public Transform[] waypoints;
    public Transform[] lookAtWaypoints;
    public GameObject lookAtMeObject;
    public float speed;
    public int currentWaypoint;

    public GameObject HMD;
    public Vector3 lastPos;
    float timer;
    public float timeBetweenChecks;
    public float minDistToTrigger;


	// Use this for initialization
	void Start () {
        currentWaypoint = 0;
        camera.transform.position = waypoints[currentWaypoint].position;
        lookAtMeObject.transform.position = (lookAtWaypoints[currentWaypoint].position);
        lastPos = HMD.transform.position;
    }

    // Update is called once per frame\
    void Update()
    {
        if (Vector3.Distance(camera.transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
                camera.transform.position = waypoints[currentWaypoint].position;
                lookAtMeObject.transform.position = (lookAtWaypoints[currentWaypoint].position);
            }
        }

        camera.transform.position += (waypoints[currentWaypoint].position - camera.transform.position).normalized * Time.deltaTime;
        lookAtMeObject.transform.position = Vector3.Lerp(lookAtMeObject.transform.position, lookAtWaypoints[currentWaypoint].position, Time.deltaTime / 5);
        camera.transform.LookAt(lookAtMeObject.transform);

        timer += Time.deltaTime;
        if (timer > timeBetweenChecks)
        {
            timer = 0.0f;
            if (Vector3.Distance(HMD.transform.position, lastPos) > minDistToTrigger)
            {
                Application.LoadLevel(0);
            }
            lastPos = HMD.transform.position;
        }
    }
}
