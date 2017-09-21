using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{

    public GameObject m_FishPrefab;
    public GameObject m_GoalPrefab;
    public float m_size = 4;


    public float m_TimeLeft;
    public float m_Time;
    public float m_Timer = 1;

    static int m_NumFish = 30;
    public static GameObject[] m_AllFish = new GameObject[m_NumFish];

    public static Vector3 m_GoalPos;// = Vector3.zero;

    private DimensionTimer m_DimTimer;

    [Space(5)]
    [Header("Players Head")]
    public Transform m_Player;
    private bool m_Onetime;
    private Vector3 m_Direction;
    private Quaternion m_LookRotation;
    public float m_RotationSpeed = 0.005f;

    // Use this for initialization
    void Start()
    {
        m_DimTimer = GetComponentInParent<DimensionTimer>();

        m_Onetime = true;

        if (GameManager.Instance)
            m_Player = GameManager.Instance.mainCamera.transform;

        m_GoalPos = new Vector3(Random.Range(-m_size + transform.position.x, m_size + transform.position.x),
             transform.position.y, Random.Range(-m_size + transform.position.z, m_size + transform.position.z));
        m_GoalPrefab.transform.position = m_GoalPos;

        for (int i = 0; i < m_NumFish; i++)
        {
            Vector3 m_pos = new Vector3(Random.Range(-m_size + transform.position.x, m_size + transform.position.x),
                 2 + transform.position.y, Random.Range(-m_size + transform.position.z, m_size + transform.position.z));

            m_AllFish[i] = (GameObject)Instantiate(m_FishPrefab, m_pos, Quaternion.identity, gameObject.transform);
            DimensionChanger.SetLayerRecursively(m_AllFish[i], gameObject.layer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50)
        {
            m_GoalPos = new Vector3(Random.Range(-m_size + transform.position.x, m_size + transform.position.x),
              transform.position.y, Random.Range(-m_size + transform.position.z, m_size + transform.position.z));

            m_GoalPrefab.transform.position = m_GoalPos;
        }

        if (!m_DimTimer)
            return;
        if (m_DimTimer.getRemainingTime() <= 20 && m_DimTimer.getRemainingTime() >= 10)
        { //decrease the width, closer to the player
            m_Time += Time.deltaTime;

            if (m_Time >= m_Timer)
            {
                if (m_size >= 1.0f)
                {
                    m_size -= 0.01f;
                    m_Time = 0;
                }
            }
        }
        else if (m_DimTimer.getRemainingTime() <= 10 && m_DimTimer.getRemainingTime() >= 0)
        {//stop fish and make them look at player
            if (m_Onetime)
            {
                for (int i = 0; i < m_NumFish; i++)
                {
                    m_AllFish[i].GetComponent<Flock>().enabled = false;
                }
                m_Onetime = false;
            }
            for (int i = 0; i < m_NumFish; i++)
            {
                m_Direction = (m_Player.position - m_AllFish[i].transform.position).normalized;
                m_LookRotation = Quaternion.LookRotation(m_Direction);
                m_AllFish[i].transform.rotation = Quaternion.Lerp(m_AllFish[i].transform.rotation, m_LookRotation, Time.deltaTime * m_RotationSpeed);
            }
        }






    }

    public Vector3 GetGoalPos()
    {
        return m_GoalPrefab.transform.position;
    }

    public Vector3 RandPos()
    {
        Vector3 temp;

        //temp = Vector3(Random)

        return Vector3.zero;
    }

}
