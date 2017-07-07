using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishOrbit : MonoBehaviour
{
    public Vector3 s_Origin;
    [Range(400, 10000)]
    public float m_angle;
   
    void Start()
    {

    }

    void Update()
    {
        transform.RotateAround(s_Origin, Vector3.up, m_angle * Time.deltaTime);
    }

    public void SetOrigin(Vector3 _Origin)
    {
        s_Origin = _Origin;
    }

    /*
    Best angle = 400
    Add in increase speed over time.
    Add in a location update when player moves.

    */
}
