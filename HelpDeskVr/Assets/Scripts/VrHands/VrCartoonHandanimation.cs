using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrCartoonHandanimation : MonoBehaviour
{

    private Animator m_animation;
    public VRTK.VRTK_ControllerEvents m_handEvent;


    //int Natural = Animator.StringToHash("Natural");
    //int GrabSmall = Animator.StringToHash("GrabSmall");
    //int Rock = Animator.StringToHash("Rock");
    //int MiddleFinger = Animator.StringToHash("MiddleFinger");
    // Use this for initialization

    int Idle = Animator.StringToHash("Idle");
    int Point = Animator.StringToHash("Point");
    int GrabLarge = Animator.StringToHash("GrabLarge");
    int GrabSmall = Animator.StringToHash("GrabSmall");
    int GrabStickUp = Animator.StringToHash("GrabStickUp");
    int GrabStickFront = Animator.StringToHash("GrabStickFront");
    int ThumbUp = Animator.StringToHash("ThumbUp");
    int Fist = Animator.StringToHash("Fist");
    int Gun = Animator.StringToHash("Gun");
    int GunShoot = Animator.StringToHash("GunShoot");
    int PushButton = Animator.StringToHash("PushButton");
    int Spread = Animator.StringToHash("Spread");
    int MiddleFinger = Animator.StringToHash("MiddleFinger");
    int Peace = Animator.StringToHash("Peace");
    int OK = Animator.StringToHash("OK");
    int Phone = Animator.StringToHash("Phone");
    int Rock = Animator.StringToHash("Rock");
    int Natural = Animator.StringToHash("Natural");
    int Number3 = Animator.StringToHash("Number3");
    int Number4 = Animator.StringToHash("Number4");

    public enum HandAnim
    {
        Idle,
        Point,
        GrabLarge,
        GrabSmall,
        GrabStickUp,
        GrabStickFront,
        ThumbUp,
        Fist,
        Gun,
        GunShoot,
        PushButton,
        Spread,
        MiddleFinger,
        Peace,
        OK,
        Phone,
        Rock,
        Natural,
        Number3,
        Number4,
        None
    }

   // public HandAnim m_Natural;
   // public HandAnim m_TriggerPress;
   // public HandAnim m_GripPress;

    private void Start()
    {
        m_animation = GetComponent<Animator>();
        m_animation.SetTrigger("Natural");

        if (m_handEvent == null)
        {
            //VRTK.VRTK_Logger.Error(VRTK.VRTK_Logger.GetCommonMessage(VRTK.VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            print("No Hand Events found");
            return;
        }
        else
        {
            print("found hands");
        }


        m_handEvent.TriggerPressed += new VRTK.ControllerInteractionEventHandler(DoTriggerPressed);
        m_handEvent.TriggerReleased += new VRTK.ControllerInteractionEventHandler(DoTriggerReleased);

        m_handEvent.GripPressed += new VRTK.ControllerInteractionEventHandler(DoGripPressed);
        m_handEvent.GripReleased += new VRTK.ControllerInteractionEventHandler(DoGripReleased);

    }
    

    private void DebugLogger(uint index, string button, string action, VRTK.ControllerInteractionEventArgs e)
    {
        Debug.Log("Controller on index '" + index + "' " + button + " has been " + action
                 + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    private void DoTriggerPressed(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print("GrabSmall!");
        m_animation.SetTrigger(GrabLarge);
    }

    private void DoTriggerReleased(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print("Natural");
        m_animation.SetTrigger(Natural);
    }

    private void DoGripPressed(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print("Rock");
        m_animation.SetTrigger(Rock);
    }

    private void DoGripReleased(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        print("Natural");
        m_animation.SetTrigger(Natural);
    }




}
