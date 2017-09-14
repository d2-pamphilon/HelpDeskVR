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
        HintsManager.Instance.Grabbed(this.gameObject);
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
        canvas.SetActive(true);
        portal.SetActive(false);
        var blueScreen = canvas.transform.FindChild("BlueScreen").gameObject;
        blueScreen.SetActive(true);
        switch (correctSolution)
        {
            case USB_PROGRAM.EncryptionTool:
                blueScreen.transform.FindChild("Explanation").GetComponent<Text>().text = "The Data in the computer was very important and you didn't encrypt it.";
                blueScreen.transform.FindChild("Online").GetComponent<Text>().text = "You can search this problem online: WHY ENCRYPTION IS IMPORTANT";
                break;
            case USB_PROGRAM.PasswordChanger:
                blueScreen.transform.FindChild("Explanation").GetComponent<Text>().text = "Your password was weak and you reused it a lot.";
                blueScreen.transform.FindChild("Online").GetComponent<Text>().text = "You can search this problem online: HOW TO CREATE STRONG PASSWORDS";
                break;
            case USB_PROGRAM.PhishingFilter:
                blueScreen.transform.FindChild("Explanation").GetComponent<Text>().text = "The computer was subject of a Phishing attack, you should have installed a spam filter!";
                blueScreen.transform.FindChild("Online").GetComponent<Text>().text = "You can search this problem online: HOW TO AVOID PHISHING ATTACKS";
                break;
            case USB_PROGRAM.PublicLogin:
                blueScreen.transform.FindChild("Explanation").GetComponent<Text>().text = "When using public computers never do anything you don't want others to see.";
                blueScreen.transform.FindChild("Online").GetComponent<Text>().text = "You can search this problem online: SAFELY USE PUBLIC COMPUTERS";
                break;
            case USB_PROGRAM.WannaCryFix:
                blueScreen.transform.FindChild("Explanation").GetComponent<Text>().text = "The computer was infected by WannaCry, a Ransomware attack, you should update more often.";
                blueScreen.transform.FindChild("Online").GetComponent<Text>().text = "You can search this problem online: HOW TO AVOID RANSOMWARE LIKE WANNACRY";
                break;
        }

        canvas.transform.FindChild("WindowsHappy").gameObject.SetActive(false);
        GameManager.Instance.scoreTracker.currentScore.laptopsFailed++;
        StartCoroutine(destroyMe());
    }

    IEnumerator laptopFixed()
    {
        GameManager.Instance.DestroyDimension(this.gameObject);
        //Laptop goes good
        canvas.SetActive(true);
        portal.SetActive(false);
        canvas.transform.FindChild("BlueScreen").gameObject.SetActive(false);
        canvas.transform.FindChild("WindowsHappy").gameObject.SetActive(true);
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
