using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamMng : MonoBehaviour {

    [SerializeField]
    private AudioClip[] Screams;
    [SerializeField]
    private float ScreamWaitTime;

    private AudioSource AS;
    [SerializeField]
    private float timer;
	
	void Start ()
    {
        timer = 0f;
        AS = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer > ScreamWaitTime)
        {
            timer = 0;
            AS.clip = Screams[Random.Range(0, Screams.Length)];
            if (AS.isActiveAndEnabled)
            {
                AS.Play();
            }
        }

	}
}
