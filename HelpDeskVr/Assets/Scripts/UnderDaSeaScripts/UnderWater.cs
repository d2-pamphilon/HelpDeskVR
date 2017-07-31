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
    public float m_timer;


    void Start()
    {
        m_Light = GameObject.Find("UnderWaterLighting").GetComponent<Light>();
        m_OriginalColour = m_Light.color;
        m_timer = 0;
        m_time = GetComponent<DimensionTimer>();
    }

    void Update()
    {
        if (m_time.elapsedTime >= 100)
        {
            if (m_timer <= 1)
            {
                m_timer += 0.0025f;
                m_Light.color = Color.Lerp(m_OriginalColour, m_EndColour, m_timer);
            }
            else
            {
                gameObject.GetComponent<UnderWater>().enabled = false;
            }

            }
    }

}
