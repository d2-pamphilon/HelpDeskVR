using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCRandError : MonoBehaviour
{

    [Header("Errors")]
    [Space(5)]
    public List<string> m_StringError;
    public Sprite m_DeathError;
    private int m_RandError;

    [Header("Canvas")]
    [Space(5)]
    public Canvas[] m_Canvas;
    private int m_CanvasNumber;


    [Header("Dimensional Timer")]
    [Space(5)]
    public DimensionTimer m_Time;



    // Use this for initialization
    void Start()
    {
        //get the dimentional timer
        m_Time = FindObjectOfType<DimensionTimer>();


        int m_rand = Random.Range(0, 100);
        m_RandError = Random.Range(0, m_StringError.Capacity);
        m_CanvasNumber = Random.Range(0, m_Canvas.Length);



        if (m_rand <= 30)
        {
            //choose a random error to display

        }
        else
        {
            //turn off script to stop the tick
            this.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
