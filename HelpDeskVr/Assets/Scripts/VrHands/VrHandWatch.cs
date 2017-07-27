using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VrHandWatch : MonoBehaviour
{
    public GameObject m_watch;
    public DimensionTimer m_DimensionTimer;

    public TMPro.TextMeshPro m_text;
    private float m_fTime;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var dims = FindObjectsOfType<DimensionTimer>();
        foreach (DimensionTimer dim in dims)
        {
            if (dim.gameObject.layer == GameManager.Instance.mainCamera.gameObject.layer)
            {
                m_DimensionTimer = dim;
                if (!m_DimensionTimer.timeOver)
                {
                    TimeSpan t = TimeSpan.FromSeconds(m_DimensionTimer.getRemainingTime());
                    string answer = string.Format("{0:D2}:{1:D2}",
                        t.Minutes,
                        t.Seconds);

                    m_text.text = answer;

                    int m_iTime = (int)m_DimensionTimer.getRemainingTime();
                    if (m_iTime >= 20)
                        m_text.color = Color.white;

                    if (m_iTime <= 20 && m_iTime >= 11)
                        m_text.color = Color.yellow;

                    if (m_iTime <= 10)
                        m_text.color = Color.red;

                    if (m_iTime <= 0)
                    {
                        m_text.color = Color.black;
                    }
                }
                else
                {
                    m_text.text = "TimeOver!!!";
                }
            }
        }
    }

}
