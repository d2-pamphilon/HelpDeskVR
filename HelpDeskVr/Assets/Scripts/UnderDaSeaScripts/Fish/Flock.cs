using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float m_speed;
    public float m_minSpeed = 0.2f;
    public float m_maxSpeed = 1f;
    float m_RotSpeed = 4.0f;

    Vector3 m_AverageHeading;
    Vector3 m_AveragePosition;
    float m_NeighbourDistance = 10f;
    public Vector3 m_NewGoalPos;

    bool m_Turn = false;

    private GlobalFlock m_FlockManager;

    // Use this for initialization
    void Start()
    {
        m_speed = Random.Range(m_minSpeed, m_maxSpeed);
        m_FlockManager = GetComponentInParent<GlobalFlock>();
        m_NewGoalPos = m_FlockManager.GetGoalPos();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!m_Turn)
        {
            m_NewGoalPos = this.transform.position - other.gameObject.transform.position;
        }

        m_Turn = true;
    }

    void OnTriggerExit(Collider other)
    {
        m_Turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.m_size)
         { m_Turn = true; }
         else
         { m_Turn = false; }*/

        if (m_Turn)
        {
            Vector3 m_direction = m_NewGoalPos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_direction), m_RotSpeed * Time.deltaTime);
            m_speed = Random.Range(m_minSpeed, m_maxSpeed);
        }
        else
        {
            if (Random.Range(0, 10) < 1)
                ApplyFishRules();
        }

        gameObject.transform.Translate(0, 0, Time.deltaTime * m_speed);
    }

    public void ApplyFishRules()
    {
        GameObject[] m_Gos;
        m_Gos = GlobalFlock.m_AllFish;

        Vector3 m_Center = Vector3.zero;
        Vector3 m_Avoid = Vector3.zero;
        float m_GroupSpeed = 0.1f;

        Vector3 m_GoalPos = GlobalFlock.m_GoalPos;
        float m_Distance;
        int m_GroupSize = 0;

        foreach (GameObject go in m_Gos)
        {
            if (go != this.gameObject)
            {
                if (go != null)
                {
                    m_Distance = Vector3.Distance(go.transform.position, this.transform.position);

                    if (m_Distance <= m_NeighbourDistance)
                    {
                        m_Center += go.transform.position;
                        m_GroupSize++;

                        if (m_Distance < 2.0f)
                            m_Avoid += (this.transform.position - go.transform.position);

                        Flock m_anotherFlock = go.GetComponent<Flock>();
                        m_GroupSpeed += m_anotherFlock.m_speed;
                    }
                }
            }
        }

        if (m_GroupSize > 0)
        {
            m_Center = m_Center / m_GroupSize + (m_GoalPos - this.transform.position);
            m_speed = m_GroupSpeed / m_GroupSize;

            Vector3 m_Direction = (m_Center + m_Avoid) - transform.position;
            if (m_Direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_Direction), m_RotSpeed * Time.deltaTime);
            }
        }
    }
}
