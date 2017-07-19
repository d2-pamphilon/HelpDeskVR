using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrHandWatch : MonoBehaviour
{
    public GameObject m_watch;
    public DimensionTimer m_DimensionTimer;

    public Text m_text;
    private float m_fTime;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<DimensionTimer>() !=null)
        {
           
            m_DimensionTimer = FindObjectOfType<DimensionTimer>();
            //change watch text size here
        }



        if (!m_DimensionTimer.timeOver)
        {
            //font size 24
            m_text.fontSize = 24;
            int m_iTime = (int)m_DimensionTimer.getRemainingTime();
            ConvertToString(m_iTime);

            if (m_iTime <= 20 && m_iTime >= 11)
                m_text.color = Color.yellow;

            if (m_iTime <= 10.0)
                m_text.color = Color.red;

            if (m_iTime <= 0.0)
            {
                m_text.color = Color.black;
            }
        }
        else
        {
            UpdateText(System.DateTime.Now.ToString("HH:mm"));
            m_text.fontSize = 15;

            /*If Clock Bugs out then remove this line*/
            m_DimensionTimer = null;
        }
    }

    public void ConvertToString(int _int)
    {
        UpdateText(_int.ToString());
    }

    public void UpdateText(string _text)
    {
        m_text.text = _text;
    }

   



}
