using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrHandCollision : MonoBehaviour {
    private bool m_Taken=false;
	// Use this for initialization
	public void IsActive(bool _b)
    {
        //gameObject.SetActive(_b);
        gameObject.GetComponent<SphereCollider>().enabled = !gameObject.GetComponent<SphereCollider>().enabled;
    }

    public void SetBool(bool _b)
    {
        m_Taken = _b;
    }
    public bool GetBool()
    {
        return m_Taken;
    }

}
