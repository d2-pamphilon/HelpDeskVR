using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{

    public GameObject m_boat;

    public float m_time;
    public float randFloat;
    public float maxTime = 10;
    public float minTime = 5;
    public int spawloc;

    void Start()
    {
        randFloat = Random.RandomRange(minTime, maxTime);
    }

        // Update is called once per frame
        void Update()
    {
        m_time += Time.deltaTime;
        if (m_time >= randFloat)
        {
            m_time = 0;
            randFloat = Random.RandomRange(minTime, maxTime);
            spawloc = Random.Range(-10, 50);
            GameObject t_GO = Instantiate(m_boat, new Vector3(transform.position.x, transform.position.y, spawloc), Quaternion.identity, gameObject.transform);
            t_GO.layer = gameObject.layer;
            // Destroy(t_GO, 10f);
        }
    }




   

}
