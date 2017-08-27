using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RoomToggle))]
public class RoomToggleEditor : Editor
{
 bool m_Toggle = true;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoomToggle m_Rt = (RoomToggle)target;

       

        if (GUILayout.Button ("Toggle"))
        {
            m_Toggle = !m_Toggle;
            m_Rt.Toggle(m_Toggle);
        }
    }
}
