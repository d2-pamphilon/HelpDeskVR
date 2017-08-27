using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomToggle : MonoBehaviour
{

    public List<GameObject> m_list;

    public void Toggle (bool _Toggle)
    {
        foreach (GameObject Gm in m_list)
            Gm.active = _Toggle;
    }
}
