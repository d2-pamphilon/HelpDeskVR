using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject m_CamHead;
    public GameObject m_Fish;
    public List<GameObject> m_SpawnLoc;
    //private Transform s_Origin;
    public Transform s_Origin;

    public float m_Time;
    public float m_Timer;

    [Range(1, 40)]
    public float m_Min;
    [Range(2, 50)]
    public float m_Max;

    public int m_SpawCount = 0;
    [Range(1, 100)]
    public int m_SpawnCap = 100;
    [Range(0, 2)]
    public float m_Tollerance;
    // Use this for initialization
    void Start()
    {
        //gameObject.transform.parent = m_CamHead.transform; //Parents the spawner to the back of the head
        //gameObject.transform.position = new Vector3(0, 0, -1);
        //s_Origin = GetComponentInParent<Transform>();
        m_Time = Random.Range(m_Min, m_Max);

        m_SpawnLoc = new List<GameObject>();
        for (int i = 0; i < 1; i++)
        {
            //Add more spawn locations when bugs are fixed
            m_SpawnLoc.Add(new GameObject());
            m_SpawnLoc[i].transform.parent = gameObject.transform;
        }

        m_SpawnLoc[0].transform.position = new Vector3(0, 0, -1);
        /*m_SpawnLoc[1].transform.position = new Vector3(-1, 0, 0);
        m_SpawnLoc[2].transform.position = new Vector3(0, 0, 1);
        m_SpawnLoc[3].transform.position = new Vector3(1, 0, 0);*/



    }

    // Update is called once per frame
    void Update()
    {
        if (!(m_SpawCount >= m_SpawnCap))
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_Time)
            {
                GameObject fish = Instantiate(m_Fish, RandSpawn(m_SpawnLoc[0]), Quaternion.identity, gameObject.transform);
                fish.GetComponent<FishOrbit>().SetOrigin(s_Origin.position);

                m_Timer = 0;
                m_Time = Random.Range(m_Min, m_Max);
                m_SpawCount++;
            }
        }
    }

    Vector3 RandSpawn(GameObject _Loc)
    {
        Vector3 m_loc = _Loc.transform.position;
        m_loc.y = Random.Range(m_loc.y - m_Tollerance, m_loc.y + m_Tollerance);
        return m_loc;
    }

}
