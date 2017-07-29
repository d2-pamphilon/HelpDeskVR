using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlaySound : MonoBehaviour {

    AudioSource sound;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float likelyhood = 0.1f;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value < likelyhood && !sound.isPlaying)
        {
            if (sound.isActiveAndEnabled)
                sound.Play();
        }
	}
}
