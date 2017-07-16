using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    public Color m_UnderwaterColour;
    private Color m_NormalColour;
    public float m_UnderWaterDensity;
    private float m_NormalDensity;
    private bool m_Underwater;

    private DimensionTimer m_time;
    public float m_timer;

    // Use this for initialization
    void Start()
    {
        m_Underwater = GetComponent<Dimension>().initialWorld;
        m_UnderwaterColour = new Color(0.22f, 0.65f, 0.77f, 0.5f);
        m_NormalColour = RenderSettings.fogColor;
        m_NormalDensity = RenderSettings.fogDensity;
        if (!RenderSettings.fog)
            RenderSettings.fog = true;
        m_time = GetComponent<DimensionTimer>();
        m_timer = m_time.getRemainingTime();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (m_Underwater)
            SetUnderWater();
        else
            SetNormal();

        if ((m_timer - 1) >= m_time.getRemainingTime())
        {
            m_UnderWaterDensity -= 0.005f;
            m_timer = m_time.getRemainingTime();
        }
        
    }


    void SetUnderWater()
    {
        RenderSettings.fogColor = m_UnderwaterColour;
        RenderSettings.fogDensity = m_UnderWaterDensity;
        print("underSeaFog");
    }

    void SetNormal()
    {
        RenderSettings.fogColor = m_NormalColour;
        RenderSettings.fogDensity = m_NormalDensity;
    }

}
