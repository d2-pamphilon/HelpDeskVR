using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITest : MonoBehaviour
{
    public string m_string;

    public GameObject WorldObject;
    public RectTransform UI_Element;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Window(0, new Rect(100, 100, 100, 20), Popwindow, "PopupWindow");
    }

    void Popwindow(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            print("Got a click in window " + windowID);

      
    }

}
