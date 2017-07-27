using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    [SerializeField]
    int NumberOfScoresToShow;

    [SerializeField]
    Text playerNames;

    [SerializeField]
    Text LaptopsFixedColumn;

    [SerializeField]
    Text LaptopsFailedColumn;

	// Use this for initialization
	void Start () {
        var scores = ScoreTracker.loadData();
        scores.Sort(new ScoreComparer());
        for (int i = 0; i < NumberOfScoresToShow && i < scores.Count; i++ )
        {
            playerNames.text += "" + scores[i].playerName + "\n";
            LaptopsFixedColumn.text += "" + scores[i].laptopsFixed + "\n";
            LaptopsFailedColumn.text += "" + scores[i].laptopsFailed + "\n";
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
