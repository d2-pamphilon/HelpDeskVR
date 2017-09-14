using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class USBController : VRTK_InteractableObject
{

    public USB_PROGRAM program;
    public bool isBad = false;


    public override void Grabbed(GameObject currentGrabbingObject)
    {
        HintsManager.Instance.Grabbed(this.gameObject);
        base.Grabbed(currentGrabbingObject);
    }
}
