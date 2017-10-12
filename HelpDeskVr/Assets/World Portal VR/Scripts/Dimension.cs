﻿/*
 * Copyright (c) 2017 VR Stuff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour {
	public Material customSkybox;

	[HideInInspector]
	public int layer;

	public bool initialWorld = false;

	//[HideInInspector]
	public List<Portal> connectedPortals;

	//[HideInInspector]
	public Camera cam;

	void Awake() {
		connectedPortals = new List<Portal> ();

		layer = LayerManager.Instance ().CreateLayer (gameObject.name);
		gameObject.layer = layer;

		Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform> ();

		foreach (Transform t in childrenTransforms) {
			t.gameObject.layer = layer;
		}


        foreach (Camera camera in Camera.allCameras) {
            if (this.initialWorld)
            {
                CameraExtensions.LayerCullingShow(camera, layer);
                if (camera.GetComponent<Skybox>())
                {
                    camera.GetComponent<Skybox>().material = customSkybox;
                }
            }
            else
            {
                CameraExtensions.LayerCullingHide(camera, layer);
            }
        }
	}

	// Use this for initialization
	void Start () {
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light l in lights)
        {
            l.cullingMask = 1 << l.gameObject.layer;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

	// You have just entered this dimension. All portals now point away from it.
	public void SwitchConnectingPortals() {
        foreach (Portal portal in connectedPortals) {
            if (portal)
            {
                if (portal.ToDimension() == this)
                {
                    portal.SwitchPortalDimensions();
                }
            }
            else
            {

            }
		}
	}
}
