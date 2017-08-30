using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCRandError : MonoBehaviour
{
    //public List<Texture> m_Errors;
    public List<MovieTexture> m_MovieTexture;
    public Sprite m_DeathError;

    [Header("Canvas")][Space(5)]
    public Canvas[] m_Canvas;
    public Image m_Image;
    public RawImage m_RawImage;
    private int m_CanvasNumber;


    [Header("Dimensional Timer")]
    [Space(5)]
    public DimensionTimer m_Time;

    private int m_RandError;

    // Use this for initialization
    void Start()
    {
        // m_Errors = new List<Texture>();
        // m_MovieTexture = new List<MovieTexture> ();
        // m_Canvas = new List<Canvas>();

        int m_rand = Random.Range(0, 100);
        m_RandError = Random.Range(0, m_MovieTexture.Capacity);
        m_CanvasNumber = Random.Range(0, m_Canvas.Length);
       // m_Canvas = GetComponentsInChildren<Canvas>(); 

        m_Time = FindObjectOfType<DimensionTimer>();

        m_Image = m_Canvas[m_CanvasNumber].GetComponentInChildren<Image>();
        m_RawImage = m_Canvas[m_CanvasNumber].GetComponentInChildren<RawImage>();


        if (m_rand <= 30)
        {
            //choose a random error to display

            //m_Image[m_CanvasNumber].GetComponentInChildren<Image>().sprite = m_Errors[m_RandError];
            m_Image.enabled = false;    //turn off the image
            m_RawImage.enabled = true;
            m_RawImage.color = Color.white;
            m_RawImage.texture = m_MovieTexture[m_RandError] as MovieTexture;
            m_MovieTexture[m_RandError].Play();


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
        if (m_Time.getRemainingTime() <= 10.0f)
        {
            m_MovieTexture[m_RandError].Stop();
            m_Image.enabled = true;    
            m_RawImage.enabled = false;
            m_Image.sprite = m_DeathError;
            m_Image.color = Color.white;
            this.enabled = false;
        }
    }
}
