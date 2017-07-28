using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;
using UnityEngine.UI;

public class DialToText : MonoBehaviour {

    public string Name;

    public Text txt;

    VRTK_Wheel[] wheels;
    public static char[] Aplhabet = {' ', 'A', 'B', 'C', 'D', 'E', 'F',
                        'G', 'H', 'I', 'J', 'K', 'L',
                        'M', 'N', 'O', 'P', 'Q', 'R',
                        'S', 'T', 'U', 'V', 'W', 'X',
                        'Y', 'Z', '1', '2', '3', '4',
                        '5', '6', '7', '8', '9', '0'};

    // Use this for initialization
    void Start () {
        wheels = GetComponentsInChildren<VRTK_Wheel>();
        Array.Sort(wheels, delegate (VRTK_Wheel wheel1, VRTK_Wheel wheel2) {
            if (wheel2.transform.position.x > wheel1.transform.position.x)
            {
                return 1;
            }
            else
            {
                return -1;
            };
        });
    }
	
	// Update is called once per frame
	void Update () {
        string str = "";
		for (int i = 0; i < wheels.Length; i++)
        {
            str += Aplhabet[(int)(wheels[i].GetValue())];
        }
        Name = str;
        if (txt)
        {
            txt.text = str;
        }
	}
}
