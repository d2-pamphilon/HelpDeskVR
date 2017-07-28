using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuclearTextGenerator : MonoBehaviour {

    public Text txt;
    public string code = "";
    public ContainerDisplay7Seg controlCode;
    public DimensionTimer dimTimer;
    bool triggered = false;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            code += DialToText.Aplhabet[(int)Random.Range(1, 37)];
        }
        txt = GetComponent<Text>();
        string str = "";
        str = "Today's nuclear launch code is:\n";
        str += code;
        str += "\n\nTODO:\n ";
        str += "Buy doughnuts\nget hacked\nChange the code";
        txt.text = str;
    }

    // Update is called once per frame
    void Update () {
		if (controlCode.text == code && !triggered)
        {
            dimTimer.elapsedTime = dimTimer.maxTime - (dimTimer.maxTime * 0.1f);
            triggered = true;
        }
	}
}
