using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Laptop : VRTK_InteractableObject
{
    public GameObject connectedDimension;
    public DimensionTimer dimTimer;

    [SerializeField]
    public VRTK_SnapDropZone USB_DropZone;

    public GameObject currentUSB;
    GameObject monitor;
    bool open;
    bool firstTimeGrab;

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
        USB_DropZone.ObjectSnappedToDropZone += USB_DropZone_ObjectSnappedToDropZone;
        USB_DropZone.ObjectUnsnappedFromDropZone += USB_DropZone_ObjectUnsnappedFromDropZone;
    }

    private void USB_DropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        currentUSB = e.snappedObject;
    }

    private void USB_DropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        currentUSB = null;
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
        yield return null;
    }

    public void selfDestruct()
    {
        //BlueScreen
        StartCoroutine(destroyMe());
    }

    public void laptopFixed()
    {
        //Laptop goes good
        StartCoroutine(destroyMe());
    }

    IEnumerator destroyMe()
    {
        yield return new WaitForSeconds(10.0f);
        //create particles of destruction
        Destroy(this.gameObject);
        yield return null;
    }

}
