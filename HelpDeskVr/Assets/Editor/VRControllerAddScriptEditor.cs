using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VRControllerAddScript))]
public class VRControllerAddScriptEditor : Editor
{


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        VRControllerAddScript m_VrController = (VRControllerAddScript)target;

        if (GUILayout.Button("AutoAdd"))
            m_VrController.AutoAddScript();
        if (GUILayout.Button("Remove"))
            m_VrController.RemoveAll();


       

    }
}
