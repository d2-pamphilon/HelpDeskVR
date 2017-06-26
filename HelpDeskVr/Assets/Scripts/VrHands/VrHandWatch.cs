using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrHandWatch : MonoBehaviour
{
    public GameObject m_watch;
    public float m_fOriginalTime;
    public Text m_text;
    private float m_fTime;
    public bool m_bStart;

    // Use this for initialization
    void Start()
    {
        //   m_watch = gameObject;
        //On start turn off watch only turns on in dimensions
        m_watch.SetActive(false);
        m_fTime = m_fOriginalTime;
        m_bStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bStart)
        {
            m_fTime -= Time.deltaTime;

            int m_iTime = (int)m_fTime;
            ConvertToString(m_iTime);

            if (m_iTime <= 20 && m_iTime >= 11)
                m_text.color = Color.yellow;

            if (m_iTime <= 10.0)
                m_text.color = Color.red;

            if (m_fTime <= 0.0)
            {
                m_fTime = m_fOriginalTime;
                m_text.color = Color.black;
                OutDimention();
            }
        }


    }



    public void InDimension(float _StartTime)
    {
        SetTime(_StartTime);
        m_bStart = true; //start timer
    }
    public void SetTime(float _fTime) // set the starting time in the world
    {
        m_fOriginalTime = _fTime;
    }


    public void OutDimention() //this shouldn't work outside of worlds
    {
        SetWatchActive(false);
        m_bStart = false;
        
    }



    public void ConvertToString(int _int)
    {
        UpdateText(_int.ToString());
    }


    public void UpdateText(string _text)
    {
        m_text.text = _text;
    }

    public void SetWatchActive(bool _b)
    {
        if (m_bStart)
            m_watch.SetActive(_b);
    }


}
