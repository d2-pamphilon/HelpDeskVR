using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    private Light m_Light;

    private Color m_OriginalColour;
    public Color m_EndColour;

    private float m_fadetime = 0.005f;
    private DimensionTimer m_time;
    private float m_timer;


    void Start()
    {
        m_Light = GameObject.Find("UnderWaterLighting").GetComponent<Light>();
        m_OriginalColour = m_Light.color;

        m_time = GetComponent<DimensionTimer>();
    }

    void Update()
    {
        if (m_time.elapsedTime >= 100)
            if (m_timer <= 1)
            {
                m_timer += Time.deltaTime / m_fadetime;
                m_Light.color = Color.Lerp(m_OriginalColour, m_EndColour, m_timer);
            }
    }

}
