using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HintState
{
    TakeLaptop,
    TakeGoodUsb,

    BadUsb,
    GrabMe,
    HeadInLaptop,
    PushButton,
    InsertUSB,
    ExtractUSB,
};

public class HintsManager : MonoBehaviour {

    public HintState hintState;
    public GameObject hintObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
