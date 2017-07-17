using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject m_CamHead;
    public GameObject m_Fish;
    private List<GameObject> m_SpawnLoc;
    private List<FishOrbit> m_FishList;
    private Light m_Lighting;

    private DimensionTimer s_Dtimer;
    //private Transform s_Origin;
    //public Transform s_Origin;

    private float m_Time;
    private float m_Timer;
    private float s_SpawnTime;

    float m_FishTime;
    float m_FishTimer;

    private int m_SpawCount = 0;
    public int m_SpawnCap = 30;
    public float m_Tollerance = 2;

    private float s_startSpeed = 100;
    private float s_maxSpeed = 1000;
    public float m_IncrementalSpeed;
    public float currntspeed;
    void Start()
    {
        GameObject dlight = GameObject.Find("Directional light");
        m_Lighting = dlight.GetComponent<Light>();

        m_FishList = new List<FishOrbit>();
        s_Dtimer = GetComponentInParent<DimensionTimer>();
        s_SpawnTime = (s_Dtimer.maxTime - 10f) / m_SpawnCap;
        m_Time = Random.Range(s_SpawnTime - 1, s_SpawnTime + 1);

        m_SpawnLoc = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            m_SpawnLoc.Add(new GameObject("SpawnLoc" + i));
            m_SpawnLoc[i].transform.parent = gameObject.transform;
        }

        m_SpawnLoc[0].transform.localPosition = new Vector3(0, 0, -1); // spawn location seems to be 0,-1,-1       
        m_SpawnLoc[1].transform.localPosition = new Vector3(-1, 0, 0);
        m_SpawnLoc[2].transform.localPosition = new Vector3(0, 0, 1);
        m_SpawnLoc[3].transform.localPosition = new Vector3(1, 0, 0);

        m_CamHead = GameObject.Find("Camera (eye)");
        float speed =  s_maxSpeed-s_startSpeed;
        m_IncrementalSpeed = s_Dtimer.maxTime/speed;
        //m_IncrementalSpeed = speed / m_FishTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!(m_SpawCount >= m_SpawnCap))
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_Time)
            {

                Vector3 val = RandSpawn(m_SpawnLoc[Random.Range(0, m_SpawnLoc.Capacity)]);

                GameObject fish = (Instantiate(m_Fish, val, Quaternion.identity, gameObject.transform));
                m_FishList.Add(fish.GetComponent<FishOrbit>());
                fish.GetComponent<FishOrbit>().SetOrigin(gameObject.transform.position);
                fish.layer = gameObject.layer;
                fish.GetComponent<FishOrbit>().m_Speed = m_IncrementalSpeed + 100;
                m_Timer = 0;
                m_Time = Random.Range(s_SpawnTime - 1, s_SpawnTime + 1);
                m_SpawCount++;

            }

        }


        m_FishTimer += Time.deltaTime;
        if (m_FishTimer >= m_FishTime)
        {
            currntspeed += m_IncrementalSpeed;
            FishSpeed();
            m_FishTimer = 0;
        }
    }

    Vector3 RandSpawn(GameObject _Loc)
    {
        Vector3 m_loc = _Loc.transform.position;
        m_loc.y = Random.Range(/*m_loc.y - m_Tollerance*/ 0.3f, m_loc.y + m_Tollerance);
        return m_loc;
    }



    void FishSpeed()
    {
        for (int i = 0; i < m_FishList.Count; i++)
        {
            if (m_FishList[i].m_Speed <= s_maxSpeed)
            {
                m_FishList[i].m_Speed = currntspeed;
            }
        }
    }
}
