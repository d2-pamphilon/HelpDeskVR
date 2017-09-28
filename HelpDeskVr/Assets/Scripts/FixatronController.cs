using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

[System.Serializable]
public enum USB_PROGRAM
{
    NONE = 0,
    Virus = 1,
    WannaCryFix = 2,
    PhishingFilter = 3,
    PasswordChanger = 4,
    EncryptionTool = 5,
    PublicLogin = 6,
    END
}


public class FixatronController : MonoBehaviour {

    private enum STATE
    {
        WaitingForUSB,
        NoProgramSelected,
        WaitingToDownload,
        Downloading,
        Installing,
        USBReady
    }

    [SerializeField]
    GameObject[] Lights;

    [SerializeField]
    List<VRTK_SnapDropZone> USB_DropZones;
         
    [SerializeField]
    List<GameObject> currentUSBs;
         
    [SerializeField]
    float timeToDownload;
     
    [ SerializeField]
    float timeToInstall;

    [SerializeField]
    GameObject MainMonitor;

    [SerializeField]
    GameObject USBMonitor;

    [Header("SoudEffects")]
    [SerializeField]
    AudioSource[] speakers;

    [SerializeField]
    AudioClip startDownload;
    [SerializeField]
    AudioClip startInstall;
    [SerializeField]
    AudioClip finishedInstall;
    [SerializeField]
    AudioClip error;
    [SerializeField]
    AudioClip errorRealBad;
    [SerializeField]
    AudioClip acceptedUSB;

    protected USB_PROGRAM currentProgram;
    private STATE currentState;

    private float timer;
    
    // Use this for initialization
    void Start () {
        for (int i = 0; i < USB_DropZones.Count; i++)
        {
            USB_DropZones[i].ObjectSnappedToDropZone += USB_DropZone_ObjectSnappedToDropZone;
            USB_DropZones[i].ObjectUnsnappedFromDropZone += USB_DropZone_ObjectUnsnappedFromDropZone;
        }
       
        currentState = STATE.WaitingForUSB;
        updateMonitors();
    }

    private void setClipAndPlay(AudioClip _clip)
    {
        foreach (var speaker in speakers)
        {
            speaker.clip = _clip;
            if (speaker.isActiveAndEnabled)
            speaker.Play();
        }
    }

    private void USB_DropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        currentUSBs.Add(e.snappedObject);
        setClipAndPlay(acceptedUSB);
        HintsManager.Instance.setHintState(HintState.InsertedUSB);
        if (currentProgram != USB_PROGRAM.NONE)
        {
            currentState = STATE.WaitingToDownload;
        }
        else
        {
            currentState = STATE.NoProgramSelected;
        }
        updateMonitors();
    }

    private void USB_DropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        if (currentState == STATE.Installing)
        {
            e.snappedObject.GetComponent<USBController>().program = currentProgram;
            e.snappedObject.GetComponent<USBController>().isBad = true;
            setClipAndPlay(errorRealBad);
        }
        else if (currentState == STATE.Downloading)
        {
            e.snappedObject.GetComponent<USBController>().program = USB_PROGRAM.NONE;
            e.snappedObject.GetComponent<USBController>().isBad = true;
            setClipAndPlay(errorRealBad);
        }
        currentUSBs.Remove(e.snappedObject);
        stopDownloadAndInstall();
        if (HintsManager.Instance.hintState == (HintState.InsertedUSB))
        {
            HintsManager.Instance.removeHint();
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (currentState == STATE.Downloading)
        {
            if (timer > timeToDownload)
            {
                currentState = STATE.Installing;
                setClipAndPlay(startInstall);
                timer = 0.0f;
            }
            updateMonitors();
        }
        else if (currentState == STATE.Installing)
        {
            if (timer > timeToInstall)
            {
                setClipAndPlay(finishedInstall);
                currentState = STATE.USBReady;
                HintsManager.Instance.setHintState(HintState.FinishedInstalling);
                foreach (GameObject currentUSB in currentUSBs)
                {
                    currentUSB.GetComponent<USBController>().program = currentProgram;
                }
                timer = 0.0f;
            }
            updateMonitors();
        }
	}

    public void updateMonitors()
    {
        switch (currentProgram)
        {
            case USB_PROGRAM.NONE:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "No Program Selected";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Select a program to get info about it";
                break;
            case USB_PROGRAM.PasswordChanger:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Password Changer";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Do you always have weak passwords? use this to change them into very secure ones!";
                break;
            case USB_PROGRAM.PhishingFilter:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Phishing Filter";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Are you swimming in spam emails and phishing attacks, get this filter to drain your inbox!";
                break;
            case USB_PROGRAM.PublicLogin:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Cache cleaner";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Have you used a public computer? With this tool hackers will not be able to steal your information after you're done...";
                break;
            case USB_PROGRAM.WannaCryFix:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "WannaCry update";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Wanna Cry? Install this update and remove vulnerabilities from your old PC!";
                break;
            case USB_PROGRAM.EncryptionTool:
                MainMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Encryption Tool";
                MainMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Do you think you have some sensible information? Encrypt your computer and no one will be able to read them!";
                break;
        }



        switch (currentState)
        {
            case STATE.WaitingForUSB:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Insert USB";
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Insert a clean usb in the panel below to start...";
                break;
            case STATE.NoProgramSelected:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Select Program";
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Select the program to install from the buttons \n\n Get info about the program selected from the other monitor";
                break;
            case STATE.WaitingToDownload:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Ready";
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Pull the lever to start downloading";
                break;
            case STATE.Downloading:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Downloading";
                string txt = "";
                for (int i = 0; i < ((timer / timeToDownload) *24); i++)
                {
                    txt += "#";
                }
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = txt;
                break;
            case STATE.Installing:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Installing";
                string txt2 = "";
                for (int i = 0; i < ((timer / timeToDownload) * 24); i++)
                {
                    txt2 += "#";
                }
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = txt2;
                break;
            case STATE.USBReady:
                USBMonitor.transform.FindChild("Title").GetComponent<Text>().text = "Finished";
                USBMonitor.transform.FindChild("Explanation").GetComponent<Text>().text = "Take the USB and use it to fix the right computer!!!";
                break;
            default:

                break;
        }
    }

    public void selectProgram(int newProgram)
    {
        if (currentState != STATE.Downloading &&
            currentState != STATE.Installing)
        {
            currentProgram = (USB_PROGRAM)newProgram;
        }
        else
        {
            setClipAndPlay(error);
        }

        if (currentState == STATE.NoProgramSelected)
        {
            currentState = STATE.WaitingToDownload;
        }

        updateMonitors();
    }

    public void startDownloading(float value, float normalizedValue)
    {
        if (normalizedValue > 95 && !speakers[0].isPlaying)
        {
            if (currentState == STATE.WaitingToDownload)
            {
                setClipAndPlay(startDownload);
                currentState = STATE.Downloading;
                timer = 0.0f;
            }
            else
            {
                setClipAndPlay(error);
            }
            updateMonitors();
        }
    }

    public void stopDownloadAndInstall()
    {
        currentState = STATE.WaitingForUSB;
        updateMonitors();
    }
}
