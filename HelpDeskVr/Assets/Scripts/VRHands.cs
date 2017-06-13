using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHands : MonoBehaviour
{

    Animator m_anim;
    int Idle = Animator.StringToHash("Idle");
    int GrabLarge = Animator.StringToHash("GrabLarge");

    public SteamVR_TrackedObject m_trackedObject;
    public SteamVR_Controller.Device m_device;

    public string[] m_InputName;

    // Use this for initialization
    void Start()
    {
        m_anim = GetComponent<Animator>();

        m_trackedObject = GetComponent<SteamVR_TrackedObject>();


        m_InputName = Input.GetJoystickNames();


    }

    // Update is called once per frame
    void Update()
    {
        m_device = SteamVR_Controller.Input((int)m_trackedObject.index);

        if (m_device.GetAxis().x != 0 || m_device.GetAxis().y != 0)
            print(m_device.GetAxis().x + " " + m_device.GetAxis().y);
        if (m_device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            print("Trigger Pressed");
            m_device.TriggerHapticPulse(700);
         }

    }
}
