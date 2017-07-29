using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNameSetter : MonoBehaviour {

   // ScoreTracker tracker;
    public GameObject scoreInput;

	// Use this for initialization
	void Start () {
    //    tracker = GetComponent<ScoreTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetName()
    {
        Instantiate(scoreInput);
    }
}
