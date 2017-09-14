using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHuman : MonoBehaviour
{

    [Header("Audio")]
    [Space(5)]
    public AudioClip[] m_AudioClip;
    public AudioSource m_AudioSource;

    private float m_Time;
    private float m_TimeSet;

    // Use this for initialization
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip[Random.Range(0, m_AudioClip.Length)];

        m_TimeSet = Random.Range(1.0f, 5.0f);


    }

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;

        if(m_Time >= m_TimeSet)
        {
            m_AudioSource.Play();
            m_AudioSource.clip = m_AudioClip[Random.Range(0, m_AudioClip.Length)];

            m_TimeSet = Random.Range(10.0f, 15.0f);
            m_Time = 0;
        }

    }
}
