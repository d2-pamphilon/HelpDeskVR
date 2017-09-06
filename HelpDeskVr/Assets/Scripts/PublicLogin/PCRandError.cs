using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCRandError : MonoBehaviour
{

    [Header("Errors")]
    [Space(5)]
    public List<string> m_StringError;
    public Sprite m_DeathError;
    private int m_RandError;

    [Header("Canvas")]
    [Space(5)]
    public Canvas[] m_Canvas;
    private int m_CanvasNumber;
    public Text m_Text;
    public Image m_Image;


    [Header("Dimensional Timer")]
    [Space(5)]
    public DimensionTimer m_Time;



    // Use this for initialization
    void Start()
    {
        //get the dimensional timer
        m_Time = FindObjectOfType<DimensionTimer>();


        int m_rand = Random.Range(0, 100);
        m_RandError = Random.Range(0, m_StringError.Capacity);
        m_CanvasNumber = Random.Range(0, m_Canvas.Length);

        m_Text = m_Canvas[m_CanvasNumber].GetComponentInChildren<Text>();
        m_Image = m_Canvas[m_CanvasNumber].GetComponentInChildren<Image>();

        if (m_rand <= 30)
        {
            //choose a random error to display
            m_Image.color = Color.white;
            m_Text.enabled = true;
            m_Text.fontStyle = FontStyle.Bold;
            m_Text.text = m_StringError[m_RandError];
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
        if (m_Time.getRemainingTime() <= 20)
        {           
            m_Image.sprite = m_DeathError;
            m_Text.enabled = false;
            this.enabled = false;
        }
        //
    }
}
