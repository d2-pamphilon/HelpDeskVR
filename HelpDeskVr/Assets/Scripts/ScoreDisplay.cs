using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour {

    ScoreTracker tracker;
    [SerializeField]
    int NumberOfScoresToShow;

	// Use this for initialization
	void Start () {
        tracker = new ScoreTracker();
        tracker.loadData();
        Text txt = GetComponent<Text>();
        tracker.scores.Sort(new ScoreComparer());
        txt.text = "\t Player \t Laptops Fixed \t Laptops Failed \n";
        for (int i = 0; i < NumberOfScoresToShow && i < tracker.scores.Count; i++ )
        {
            txt.text += i + ") \t" + tracker.scores[i].ToString();
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
