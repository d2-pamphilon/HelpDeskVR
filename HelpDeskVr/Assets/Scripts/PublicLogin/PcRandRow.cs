using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcRandRow : MonoBehaviour
{
    public List<GameObject> m_Prefab;
    public List<Transform> m_CompLoc;


    // Use this for initialization
    void Start()
    {
        m_CompLoc = new List<Transform>();
        int num=0;

        foreach (Transform child in transform)
        {
            m_CompLoc.Add(child);
            GameObject m_Pc = Instantiate(m_Prefab[Random.Range(0, m_Prefab.Count)], child.position, Quaternion.identity, child);
            DimensionChanger.SetLayerRecursively(m_Pc, gameObject.layer);
            num++;
            if (num >=6)
            {
                return;
            }
        }

    }

}
