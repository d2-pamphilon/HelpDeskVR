using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour {

	void OnCollisionStay(Collision col)
    {
        var audio = GetComponent<AudioSource>();
        if (!audio.isPlaying && col.relativeVelocity.magnitude >= .5)
        {
            audio.volume = col.relativeVelocity.magnitude / 20;
            audio.Play();
        }
    }
}
