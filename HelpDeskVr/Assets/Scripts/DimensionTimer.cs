using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dimension))]
public class DimensionTimer : MonoBehaviour {

    public float maxTime;
    public float elapsedTime;
    public bool timeOver;

	// Use this for initialization
	void Start () {
        //maxTime = 0.0f;
        elapsedTime = 0.0f;
        timeOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= maxTime)
        {
            timeOver = true;
        }
	}

    float getElapsedTime()
    {
        return (elapsedTime);
    }

    float getRemainingTime()
    {
        return (maxTime-elapsedTime);
    }
}
