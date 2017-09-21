using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractSceneTrigger : MonoBehaviour {

    public GameObject HMD;
    public Vector3 lastPos;
    public float timer;
    public float timeBetweenChecks;
    public float minDistToTrigger;
    public float minTimeToTrigger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > timeBetweenChecks)
        {
            if (Vector3.Distance(HMD.transform.position, lastPos) > minDistToTrigger)
            {
                timer = 0.0f;
            }
            else if (timer > minTimeToTrigger)
            {
                Application.LoadLevel(3);
            }

            lastPos = HMD.transform.position;
        }
    }
}
