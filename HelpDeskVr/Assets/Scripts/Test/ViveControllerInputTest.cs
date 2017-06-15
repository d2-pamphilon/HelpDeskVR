using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

    private SteamVR_TrackedObject trackObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackObj.index); }
    }
    void Awake()
    {
        trackObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Update is called once per frame
	void Update ()
    {
		if( Controller.GetAxis() != Vector2.zero)
         Debug.Log(gameObject.name + Controller.GetAxis());

        if (Controller.GetHairTriggerDown())
            Debug.Log(gameObject.name + "Trigger press");

        if (Controller.GetHairTriggerUp())
            Debug.Log(gameObject.name + "Trigger release");

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            Debug.Log(gameObject.name + "Grip press");

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            Debug.Log(gameObject.name + "Grip release");
        
    }
}
