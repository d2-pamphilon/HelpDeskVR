using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRandError : MonoBehaviour
{
    public List<GameObject> m_Errors;
    public Canvas m_canvas;

    // Use this for initialization
    void Start()
    {
        m_Errors = new List<GameObject>();

        int m_rand = Random.Range(0, 100);


        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
