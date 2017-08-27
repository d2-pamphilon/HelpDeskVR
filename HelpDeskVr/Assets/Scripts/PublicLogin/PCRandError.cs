using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCRandError : MonoBehaviour
{
    public List<Texture> m_Errors;
    public List<MovieTexture> m_MovieTexture;
    public Sprite m_DeathError;

    [Header("ComputerScreen")]
    [Space(1)]
    public Image[] m_Image;
    public int m_CanvasNumber;

    [Header("Dimensional Timer")]
    [Space(5)]
    public DimensionTimer m_Time;

    // Use this for initialization
    void Start()
    {
       // m_Errors = new List<Texture>();
       // m_MovieTexture = new List<MovieTexture> ();
       // m_Canvas = new List<Canvas>();

        int m_rand = Random.Range(0, 100);
        int m_RandError = Random.Range(0, m_Errors.Capacity);
       // m_CanvasNumber = Random.Range(0, m_Canvas.Capacity);
        m_Image = GetComponentsInChildren<Image>();

        m_Time = FindObjectOfType<DimensionTimer>();

        if (m_rand <= 30)
        {
            //choose a random error to display

            // m_Canvas[m_CanvasNumber].GetComponentInChildren<Image>().sprite = m_Errors[m_RandError];
            /*Renderer m_Render = GetComponent<Renderer>();
            MovieTexture movie = (MovieTexture)m_Render.material.mainTexture;*/


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
        if (m_Time.getRemainingTime() <= 100.0f)
        {
            m_Image[m_CanvasNumber].sprite = m_DeathError;
            m_Image[m_CanvasNumber].color = Color.white;
        }
    }
}
