using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetTextFromFile : MonoBehaviour {

    Text txt;

    [SerializeField]
    TextAsset txtAsset;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        txt.text = txtAsset.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
