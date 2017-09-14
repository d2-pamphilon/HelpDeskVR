using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

    public GameObject player;
    public GameObject attachedTo;

	// Use this for initialization
	void Start () {
        player = GameManager.Instance.mainCamera.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
        Vector3 NewPos = (attachedTo.transform.position + 
                              ((player.transform.position - attachedTo.transform.position)/10));
        NewPos.y += 0.3f;

        transform.position = NewPos;
        
	}
}
