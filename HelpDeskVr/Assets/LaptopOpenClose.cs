using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LaptopOpenClose : VRTK_InteractableObject
{

    GameObject monitor;
    bool open;

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        if (open)
        {
            open = false;
            CloseLaptop();
        }
        else
        {
            open = true;
            CloseLaptop();
        }
    }

    // Use this for initialization
    void Start () {

        open = true;
        monitor = transform.FindChild("laptop_monitor").gameObject;
	}

    public void OpenLaptop()
    {
        monitor.transform.Rotate(new Vector3(0, 0, 120));
    }

    public void CloseLaptop()
    {
        monitor.transform.Rotate(new Vector3(0, 0, -120));
    }
    
}
