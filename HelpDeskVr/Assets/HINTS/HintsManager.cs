using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HintState
{
    NONE,
    TakeLaptop,
    TakeGoodUsb,
    HoldingBadUsb,
    HoldingLaptop,
    HoldingGoodUSB,
    InsertedUSB,
    FinishedInstalling
};

public enum HintImage
{
    BadUsb,
    GrabMe,
    HeadInLaptop,
    PushButton,
    InsertUSB,
    ExtractUSB
}

[System.Serializable]
public struct HintImagePair
{
    public HintImage hint;
    public Sprite img;
}

public class HintsManager : MonoBehaviour {

    public static HintsManager Instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public HintState hintState;
    public GameObject hint;

    [SerializeField]
    public HintImagePair[] images;

    public Dictionary<HintState, bool> stateAllower;

    bool found = false;


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    
    
    // Use this for initialization
    void Start () {
        stateAllower = new Dictionary<HintState, bool>();
        stateAllower[HintState.TakeLaptop] = true;
        stateAllower[HintState.TakeGoodUsb] = true;
        stateAllower[HintState.HoldingBadUsb] = true;
        stateAllower[HintState.HoldingLaptop] = true;
        stateAllower[HintState.HoldingGoodUSB] = true;
        stateAllower[HintState.InsertedUSB] = true;
        stateAllower[HintState.FinishedInstalling] = true;
    }
	
	// Update is called once per frame
	void Update () {
        found = false;
        switch (hintState)
        {
            case HintState.NONE:
                removeHint();
                break;
            case HintState.TakeLaptop:
                
                foreach (KeyValuePair<GameObject, GameObject> pair in GameManager.Instance.createdDimensions)
                {
                    if (PlayerLooking.IsPlayerLookingAt(pair.Key))
                    {
                        setHint(pair.Key, HintImage.GrabMe);
                        found = true;
                        break;
                    }

                }
                if (!found)
                {
                    removeHint();
                }
                break;

            case HintState.TakeGoodUsb:
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("USB"))
                {
                    if (!go.GetComponent<USBController>().isBad)
                    {
                        if (PlayerLooking.IsPlayerLookingAt(go))
                        {
                            setHint(go, HintImage.GrabMe);
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    removeHint();
                }
                break;
            case HintState.HoldingBadUsb:
                // all done externally, i hope
                break;
            case HintState.HoldingLaptop:
                // all done externally, i hope
                break;

            case HintState.HoldingGoodUSB:
                setHint(GameObject.FindGameObjectWithTag("USBSlots"), HintImage.InsertUSB);
                break;
            case HintState.InsertedUSB:
                setHint(GameObject.FindGameObjectWithTag("Buttons"), HintImage.PushButton);
                break;

            case HintState.FinishedInstalling:
                setHint(GameObject.FindGameObjectWithTag("USBSlots"), HintImage.ExtractUSB);
                break;
        }
	}

    public void setHint(GameObject attachedTo, HintImage imgEnum)
    {
        if (!hint.activeSelf)
        {
            hint.SetActive(true);
        }
        hint.GetComponent<Hint>().attachedTo = attachedTo;
        foreach (HintImagePair pair in images)
        {
            if (pair.hint == imgEnum)
            {
                hint.GetComponent<SpriteRenderer>().sprite = pair.img;
                break;
            }
        }
    }

    public void removeHint()
    {
        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
    }

    public void Grabbed(GameObject grabbed)
    {
        if (grabbed.GetComponent<Laptop>())
        {
            if (setHintState(HintState.HoldingLaptop))
            setHint(grabbed, HintImage.HeadInLaptop);
        }
        else if (grabbed.GetComponent<USBController>())
        {
            if (grabbed.GetComponent<USBController>().isBad)
            {
                if (setHintState(HintState.HoldingBadUsb))
                    setHint(grabbed, HintImage.BadUsb);
            }
            else
            {
                setHintState(HintState.HoldingGoodUSB);
                //setHint(grabbed, HintImage.BadUsb);
            }
        }
    }

    public bool setHintState(HintState state)
    {
        if (stateAllower[state])
        {
            hintState = state;
            stateAllower[state] = false;
            return true;
        }
        else
        {
            //hintState = HintState.NONE;
            return false;
        }
    }

}
