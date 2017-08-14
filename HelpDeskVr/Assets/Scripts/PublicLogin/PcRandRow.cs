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
            switch (Random.Range(0, 2))
            {
                case 0:
                    Instantiate(m_Prefab[0], child.position, Quaternion.identity, child);
                    break;
                case 1:
                    Instantiate(m_Prefab[1], child.position, Quaternion.identity, child);
                    break;
            }
            num++;
            if (num >=6)
            {
                return;
            }
        }

    }

}
