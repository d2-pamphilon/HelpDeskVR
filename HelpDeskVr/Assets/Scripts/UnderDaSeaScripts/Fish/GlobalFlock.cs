using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{

    public GameObject m_FishPrefab;
    public GameObject m_GoalPrefab;
    public static int m_size = 2;

    static int m_NumFish = 30;
    public static GameObject[] m_AllFish = new GameObject[m_NumFish];
    
    public static Vector3 m_GoalPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
     
        for (int i = 0; i < m_NumFish; i++)
        {
            Vector3 m_pos = new Vector3(Random.Range(-m_size + transform.position.x, m_size + transform.position.x),
                Random.Range(0.5f + transform.position.y, 2 + transform.position.y), Random.Range(-m_size + transform.position.z, m_size + transform.position.z));
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
    }

    public Vector3 GetGoalPos()
    {
        return m_GoalPrefab.transform.position;
    }

}
