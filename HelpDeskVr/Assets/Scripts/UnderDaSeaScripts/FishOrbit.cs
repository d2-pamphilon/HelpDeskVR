using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishOrbit : MonoBehaviour
{
    public FishSpawn s_FishSpawn;
    public Vector3 m_Origin;
    public float m_Speed;
    
    void Start()
    {
        s_FishSpawn = GetComponentInParent<FishSpawn>();
    }

    void Update()
    {
        m_Origin.y = s_FishSpawn.m_CamHead.transform.position.y;
        transform.RotateAround(m_Origin, Vector3.up, m_Speed * Time.deltaTime);
        transform.LookAt(m_Origin);
    }

    public void SetOrigin(Vector3 _Origin)
    {
        m_Origin = _Origin;
    }

    /*
    Best angle = 400
    Add in increase speed over time.
    Add in a location update when player moves.

    */
}
