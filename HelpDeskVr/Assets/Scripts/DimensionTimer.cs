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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GameManager.Instance.cameraRig.layer == this.gameObject.layer)
            {
                maxTime += 30;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (GameManager.Instance.cameraRig.layer == this.gameObject.layer)
            {
                maxTime -= 30;
            }
        }
    }

    float getElapsedTime()
    {
        return (elapsedTime);
    }

    public float getRemainingTime()
    {
        return (maxTime-elapsedTime);
    }
}
