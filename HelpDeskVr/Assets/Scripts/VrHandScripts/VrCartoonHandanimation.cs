using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrCartoonHandanimation : MonoBehaviour
{

    private Animator m_animation;
    public VRTK.VRTK_ControllerEvents m_handEvent;

   
    int Natural = Animator.StringToHash("Natural");
    int GrabSmall = Animator.StringToHash("GrabSmall");
    int Rock = Animator.StringToHash("Rock");
    int MiddleFinger = Animator.StringToHash("MiddleFinger");
    // Use this for initialization
    private void Start()
    {
        m_animation = GetComponent<Animator>();
        m_animation.SetTrigger(Natural);

        if (m_handEvent == null)
        {
            VRTK.VRTK_Logger.Error(VRTK.VRTK_Logger.GetCommonMessage(VRTK.VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        m_handEvent.TriggerPressed += new VRTK.ControllerInteractionEventHandler(DoTriggerPressed);
        m_handEvent.TriggerReleased += new VRTK.ControllerInteractionEventHandler(DoTriggerReleased);

        m_handEvent.GripPressed += new VRTK.ControllerInteractionEventHandler(DoGripPressed);
        m_handEvent.GripReleased += new VRTK.ControllerInteractionEventHandler(DoGripReleased);
        
    }

    
           
        

    // Update is called once per frame
    private void DebugLogger(uint index, string button, string action, VRTK.ControllerInteractionEventArgs e)
    {
        VRTK.VRTK_Logger.Info("Controller on index '" + index + "' " + button + " has been " + action
                + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    private void DoTriggerPressed(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print("fist!");
        m_animation.SetTrigger(GrabSmall);
    }

    private void DoTriggerReleased(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print ("Idle");
        m_animation.SetTrigger(Natural);
    }

    private void DoGripPressed(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        m_animation.SetTrigger(Rock);
    }

    private void DoGripReleased(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        m_animation.SetTrigger(Natural);
    }


}
