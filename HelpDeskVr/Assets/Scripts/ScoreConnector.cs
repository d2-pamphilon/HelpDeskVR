using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreConnector : MonoBehaviour {

    public Text laptopsFixed;
    public Text laptopsFailed;
    public Text playerNameInput;

    public ScoreTracker tracker;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (tracker)
        {
            laptopsFixed.text = "" + tracker.currentScore.laptopsFixed;
            laptopsFailed.text = "" + tracker.currentScore.laptopsFailed;
            tracker.currentScore.playerName = playerNameInput.text;
        }
        else
        {
            tracker = FindObjectOfType<ScoreTracker>();
        }
	}

    public void Save()
    {
        tracker.saveData();
        Destroy(tracker);
    }
}
