using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class MissileSiloController : MonoBehaviour {

    [SerializeField]
    DimensionTimer m_timer;

    Action o_countdown;//= ContextCallOnlyOnce.callOnlyOnce(Countdown);
    Action o_door;//= ContextCallOnlyOnce.callOnlyOnce(DoorOpening);
    Action o_missTurnOn;// = ContextCallOnlyOnce.callOnlyOnce(MissileTurnOn);
    Action o_missLaunch;// = ContextCallOnlyOnce.callOnlyOnce(MissileLaunch);

    [SerializeField]
    AudioClip[] m_countdown;

    [SerializeField]
    GameObject m_door;

    [SerializeField]
    ParticleSystem[] m_missileParticles;

    [SerializeField]
    GameObject m_missile;

    // Use this for initialization
    void Start () {
        o_countdown = ContextCallOnlyOnce.callOnlyOnce(Countdown);
        o_door = ContextCallOnlyOnce.callOnlyOnce(DoorOpening);
        o_missTurnOn = ContextCallOnlyOnce.callOnlyOnce(MissileTurnOn);
        o_missLaunch = ContextCallOnlyOnce.callOnlyOnce(MissileLaunch);
    }
	
	// Update is called once per frame
	void Update () {
        float timeLeft = m_timer.getRemainingTime();

        if (timeLeft > 25 && timeLeft < 60)
        {
            o_missTurnOn();
        }
        if (timeLeft > 11 && timeLeft < 25)
        {
            o_door();
        }
        if (timeLeft > 5 && timeLeft < 16)
        {
            o_countdown();
        }
        if (timeLeft < 5)
        {
            MissileLaunch();
        }
    }

    void Countdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        for (int i = 10; i >= 0; i--)
        {
            GetComponent<AudioSource>().clip = m_countdown[i];
            if (GetComponent<AudioSource>().isActiveAndEnabled)
                GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1.0f);
        }
        yield return null;
    }

    void DoorOpening()
    {

    }

    void MissileTurnOn()
    {
        foreach (var p in m_missileParticles)
        {
            p.enableEmission = true;
        }
    }

    void MissileLaunch()
    {
        m_missile.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 1.5f, 0.0f));
    }
}

public class ContextCallOnlyOnce
{
    public bool AlreadyCalled;

    static public Action callOnlyOnce(Action action)
    {
        var context = new ContextCallOnlyOnce();
        Action ret = () =>
        {
            if (false == context.AlreadyCalled)
            {
                action();
                context.AlreadyCalled = true;
            }
        };

        return ret;
    }
}