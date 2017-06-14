using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Laptop : VRTK_InteractableObject
{

    GameObject monitor;
    bool open;
    bool firstTimeGrab;

    public Virus.ComputerVirus_Base virusScript;

    public override void Grabbed(GameObject currentGrabbingObject)
    {
        base.Grabbed(currentGrabbingObject);
        if (firstTimeGrab)
        {
            firstTimeGrab = false;
            StartCoroutine(OpenMonitor());
        }
    }

    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        if (open)
        {
            StartCoroutine(CloseMonitor());
        }
        else
        {
            StartCoroutine(OpenMonitor());
        }
    }
    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
        if (open)
        {
            StartCoroutine(CloseMonitor());
        }
        else
        {
            StartCoroutine(OpenMonitor());
        }
    }

    // Use this for initialization
    protected void Start () {
        firstTimeGrab = true;
        open = false;
        monitor = transform.FindChild("laptop_monitor").gameObject;
	}

    protected override void Update()
    {
        base.Update();
    }
    
    IEnumerator OpenMonitor()
    {
        open = true;
        for (int i = 0; i < 110; i++)
        {
            monitor.transform.Rotate(new Vector3(0, 0, 1));
            yield return new WaitForSeconds(0.01f);
        }
        virusScript.VirusActivate();
        yield return null;
    }

    IEnumerator CloseMonitor()
    {
        open = false;
        for (int i = 0; i < 110; i++)
        {
            monitor.transform.Rotate(new Vector3(0, 0, -1));
            yield return new WaitForSeconds(0.01f);
        }
        virusScript.VirusDisable();
        yield return null;
    }
}
