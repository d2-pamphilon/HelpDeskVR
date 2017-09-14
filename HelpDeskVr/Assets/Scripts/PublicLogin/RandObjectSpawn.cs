using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandObjectSpawn : MonoBehaviour
{
    public GameObject[] m_Objects;


    // Use this for initialization
    void Start()
    {
        int m_num = Random.Range(0, 10);
        if (m_num == 0 || m_num == 1)
        {
            GameObject m_object = Instantiate(m_Objects[m_num], gameObject.transform.position, Quaternion.identity, transform);
            DimensionChanger.SetLayerRecursively(m_object, gameObject.layer);
        }
    }


}
