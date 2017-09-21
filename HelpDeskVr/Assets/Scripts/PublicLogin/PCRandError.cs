using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCRandError : MonoBehaviour
{

    [Header("Errors")]
    [Space(5)]
    public List<GameObject> m_Errors;
    private GameObject m_Error;
    public Sprite m_DeathError;
    private int m_RandError;
    public float m_IncVal;

    [Header("Canvas")]
    [Space(5)]
    public Canvas[] m_Canvas;
    private int m_CanvasNumber;
    public Text m_Text;
    public Image m_DeathImage;
    public Image m_BarImage;


    [Header("DimensionTimer")]
    [Space(5)]
    public DimensionTimer m_DTime;

    [Header("Audio")]
    [Space(5)]
    public AudioClip[] m_AudioClip;
    public AudioSource m_AudioSource;

    //Time
    private float m_Time;
    private bool m_Playsound;

    // Use this for initialization
    void Start()
    {
        //find the dimension timer
        GameObject go = this.gameObject;
        while (go.transform.parent != null)
        {
            go = go.transform.parent.gameObject;
        }
        m_DTime = go.GetComponent<DimensionTimer>();

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip[Random.Range(0, m_AudioClip.Length)];
        m_Playsound = true;

        int m_rand = Random.Range(0, 100);
        m_RandError = Random.Range(0, m_Errors.Capacity);
        m_CanvasNumber = Random.Range(0, m_Canvas.Length);
        m_IncVal = Random.Range(0.01f, 0.05f);

        m_Text = m_Canvas[m_CanvasNumber].GetComponentInChildren<Text>();
        Image[] m_im = m_Canvas[m_CanvasNumber].GetComponentsInChildren<Image>();
        m_DeathImage = m_im[0];
        if (m_im.Length == 2)
        {
            m_BarImage = m_im[1];
        }

        if (m_rand <= 75)
        {
            //choose a random error to display
            m_DeathImage.color = Color.white;
            if (m_BarImage)
            {

                m_BarImage.enabled = true;
                m_BarImage.fillAmount = 0;
            }
            m_Error = Instantiate(m_Errors[m_RandError]);
            m_Error.transform.SetParent(m_Canvas[m_CanvasNumber].gameObject.transform);
            //m_Text.enabled = true;
            //m_Text.fontStyle = FontStyle.Bold;
            //m_Text.text = m_StringError[m_RandError];
        }
        else
        {
            //turn off script to stop the tick
            m_DeathImage.gameObject.SetActive(false);
            this.enabled = false;
        }

    }


    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;
        if (!m_DTime)
            return;
        if (m_DTime.getRemainingTime() <= 90)
        {
            if (m_DTime.getRemainingTime() <= 5)
            {
                m_Error.SetActive(false);
                m_DeathImage.sprite = m_DeathError;
                m_BarImage.enabled = false;
                this.enabled = false;
            }

            if ((m_BarImage.fillAmount <= 1f) && m_Time >= 1f)
            {
                m_Time = 0;
                m_BarImage.fillAmount += m_IncVal;
            }
            if (m_BarImage.fillAmount >= 1f)
            {
                m_Error.SetActive(false);
                m_DeathImage.sprite = m_DeathError;
                m_BarImage.enabled = false;
                this.enabled = false;
                if (m_Playsound)
                {
                    m_AudioSource.Play();
                    m_Playsound = false;
                }
            }

        }
    }
}
