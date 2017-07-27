using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Laptop : VRTK_InteractableObject
{

    [Header("Laptop Options")]
    public GameObject connectedDimension;
    public DimensionTimer dimTimer;

    public USB_PROGRAM correctSolution;

    [SerializeField]
    public VRTK_SnapDropZone USB_DropZone;

    public GameObject currentUSB;
    GameObject monitor;
    bool open;
    bool firstTimeGrab;

    [SerializeField]
    GameObject portal;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    Text timerText;

    [SerializeField]
    GameObject smoke;

    protected override void Update()
    {
        base.Update();

        int timeLeft = (int)(dimTimer.maxTime - dimTimer.elapsedTime);
        int mins = timeLeft / 60;
        int secs = timeLeft % 60;

        timerText.text = mins.ToString("00") + ":" + secs.ToString("00");
    }

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
        if (currentUSB.GetComponent<USBController>().program == correctSolution)
        {
            StartCoroutine(laptopFixed());
        }
        else
        {
            dimTimer.maxTime = 0.0f;
        }
        Destroy(e.snappedObject.gameObject);
        currentUSB = null;
    }

    private void USB_DropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        currentUSB = null;
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
        canvas.active = true;
        portal.active = false;
        canvas.transform.FindChild("BlueScreen").gameObject.active = true;
        canvas.transform.FindChild("WindowsHappy").gameObject.active = false;
        GameManager.Instance.scoreTracker.currentScore.laptopsFailed++;
        StartCoroutine(destroyMe());
    }

    IEnumerator laptopFixed()
    {
        GameManager.Instance.DestroyDimension(this.gameObject);
        //Laptop goes good
        canvas.active = true;
        portal.active = false;
        canvas.transform.FindChild("BlueScreen").gameObject.active = false;
        canvas.transform.FindChild("WindowsHappy").gameObject.active = true;
        GameManager.Instance.scoreTracker.currentScore.laptopsFixed++;
        yield return new WaitForSeconds(10.0f);
        Instantiate(smoke, this.transform.position, this.transform.rotation, this.transform.parent);
        Destroy(this.gameObject);
        yield return null;
    }

    IEnumerator destroyMe()
    {
        GameManager.Instance.createdDimensions.Remove(this.gameObject);
        yield return new WaitForSeconds(10.0f);
        //create particles of destruction
        Instantiate(smoke, this.transform.position, this.transform.rotation, this.transform.parent);
        Destroy(this.gameObject);
        yield return null;
    }

}
