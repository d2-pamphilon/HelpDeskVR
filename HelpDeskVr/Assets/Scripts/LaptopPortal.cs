using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopPortal : Portal {

    [SerializeField]
    public List<GameObject> dimensionChanging;

    protected override void SwitchDimensions()
    {
        foreach (GameObject go in dimensionChanging)
        {
            DimensionChanger.SwitchDimensions(go, FromDimension(), ToDimension());
        }
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light l in lights)
        {
            l.enabled = l.gameObject.layer == ToDimension().layer;
        }

        AudioSource[] sounds = FindObjectsOfType<AudioSource>();
        foreach (AudioSource s in sounds)
        {
            s.enabled = s.gameObject.layer == ToDimension().layer;
        }

        ParticleSystem[] particle = FindObjectsOfType<ParticleSystem>();
        foreach (ParticleSystem p in particle)
        {
            p.enableEmission = p.gameObject.layer == ToDimension().layer;
        }

        base.SwitchDimensions();
    }
}
