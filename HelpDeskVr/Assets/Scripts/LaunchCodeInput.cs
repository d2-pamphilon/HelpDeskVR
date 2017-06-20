using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LaunchCodeInput : MonoBehaviour {

    [SerializeField]
    ContainerDisplay7Seg display;
    int cursorPos;

    [SerializeField]
    int stringLength;
    public string correctCode;

	// Use this for initialization
	void Start () {
        cursorPos = 0;
        stringLength = 10;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextInput(string letter)
    {
        StringBuilder sb = new StringBuilder(display.text);
        sb[cursorPos] = letter[0];
        display.text = sb.ToString();
        cursorPos++;
        if (cursorPos == stringLength)
        {
            cursorPos = 0;
        }
    }
}
