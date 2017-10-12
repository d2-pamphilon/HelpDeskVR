using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

    public GameObject player;
    public GameObject attachedTo;

    public GameObject LineBegin;
    public GameObject LineMid;
    public GameObject LineEnd;


    // Use this for initialization
    void Start () {
        player = GameManager.Instance.mainCamera.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (attachedTo)
        {
            transform.LookAt(player.transform.position);
            Vector3 NewPos = (attachedTo.transform.position +
                                  ((player.transform.position - attachedTo.transform.position) / 10));

            NewPos.y += 0.3f;

            transform.position = NewPos;

            LineBegin.transform.position = transform.position;
            Vector3 center = attachedTo.transform.position;
            int objs = 1;
            foreach (Transform go in attachedTo.transform.GetComponentsInChildren<Transform>())
            {
                center += go.position;
                objs++;
            }
            center /= objs;

            LineEnd.transform.position = center;
            LineMid.transform.position = (center + new Vector3(0.0f, 0.1f, 0.0f));
        }
	}
}
