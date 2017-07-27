using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialToText))]
public class DialTo7segDisplay : MonoBehaviour {

    DialToText dtt;
    public ContainerDisplay7Seg seg7;

	// Use this for initialization
	void Start () {
        dtt = GetComponent<DialToText>();
	}
	
	// Update is called once per frame
	void Update () {
        seg7.text = dtt.Name;
	}
}
