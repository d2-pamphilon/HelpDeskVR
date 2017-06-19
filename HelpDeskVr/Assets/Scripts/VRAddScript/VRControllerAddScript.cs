using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VRControllerAddScript : MonoBehaviour
{

    // Use this for initialization
    public enum Scripts
    {
        PickUp,
        pickUp_Drop,
        None
    };

    // [Header("AutoAddScript adding scripts")]
    // [Tooltip("Choose between to pickup and hold of pickup then drop on trigger release")]
    // public Scripts m_ScriptChoice = Scripts.None;


    public void AutoAddScript()
    {
        //switch (m_ScriptChoice)
        //{
        //    case Scripts.PickUp:
        //        gameObject.AddComponent<VRTK.GrabAttachMechanics.VRTK_TrackObjectGrabAttach> ();
        //        break;
        //    case Scripts.pickUp_Drop:
        //        //gameObject.AddComponent<VRTK.GrabAttachMechanics.>();
        //        break;
        //}

        if (gameObject.GetComponent<Rigidbody>() == null)
            gameObject.AddComponent<Rigidbody>();

        if (gameObject.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>() == null)
        {
            gameObject.AddComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
            gameObject.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>().precisionGrab = true;
            gameObject.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>().breakForce = 10000;
        }

       

        if (gameObject.GetComponent<VRTK.VRTK_InteractableObject>() == null)
        {
            gameObject.AddComponent<VRTK.VRTK_InteractableObject>();
            gameObject.GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable = true;
            gameObject.GetComponent<VRTK.VRTK_InteractableObject>().grabOverrideButton = VRTK.VRTK_ControllerEvents.ButtonAlias.Trigger_Press;
            gameObject.GetComponent<VRTK.VRTK_InteractableObject>().grabAttachMechanicScript = gameObject.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
            //gameObject.GetComponent<VRTK.VRTK_InteractableObject>().secondaryGrabActionScript = gameObject.GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
            gameObject.GetComponent<VRTK.VRTK_InteractableObject>().isUsable = true;
        }

        if (gameObject.GetComponent<VRTK.VRTK_InteractControllerAppearance>() == null)
            gameObject.AddComponent<VRTK.VRTK_InteractControllerAppearance>();

        if (gameObject.GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>() == null)
            gameObject.AddComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();



        //DestroyImmediate(GetComponent<VRControllerAddScript>());
    }

    public void RemoveAll()
    {
        DestroyImmediate(GetComponent<Rigidbody>());
        DestroyImmediate(GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>());
        DestroyImmediate(GetComponent<VRTK.VRTK_InteractableObject>());
        DestroyImmediate(GetComponent<VRTK.VRTK_InteractControllerAppearance>());
        DestroyImmediate(GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>());
    }


}
