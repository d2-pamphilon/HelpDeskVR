using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display7SegTimeSetter : MonoBehaviour {

    public int Hours = 10;
    public int Minutes = 00;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        string text = Hours.ToString("00") + ":" + Minutes.ToString("00");

        if (System.DateTime.Now.Millisecond % 1000 > 500) text = text.Substring(0, 2) + ' ' + text.Substring(3, 2);

        GetComponent<Clock4Digits>().text = text;
    }
}
