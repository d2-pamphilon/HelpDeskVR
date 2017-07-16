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

    public bool m_bInDimen; //in dimention or not



    // Use this for initialization
    void Start()
    {
        
        m_bInDimen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<DimensionTimer>() !=null)
        {
            m_bInDimen = true;
            //change watch text size here
        }
        else
        {
            m_bInDimen = false;
            //change watch text size here
        }


        if (m_bInDimen)
        {
            int m_iTime = (int)m_DimensionTimer.getRemainingTime();
            ConvertToString(m_iTime);

            if (m_iTime <= 20 && m_iTime >= 11)
                m_text.color = Color.yellow;

            if (m_iTime <= 10.0)
                m_text.color = Color.red;

            if (m_iTime <= 0.0)
            {
                m_bInDimen = false;
                m_text.color = Color.black;
            }
        }
        else
        {
            UpdateText(System.DateTime.Now.ToString("HH:mm:ss"));
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
