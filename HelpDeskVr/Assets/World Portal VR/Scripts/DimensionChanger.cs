/*
 * Copyright (c) 2017 VR Stuff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DimensionChanger {

    public static void SwitchDimensions(GameObject obj, Dimension fromDimension, Dimension toDimension) {
		obj.layer = toDimension.layer;
        SetLayerRecursively(obj.gameObject, toDimension.layer);

        if (obj.transform.parent.gameObject.GetComponent<Dimension>() == fromDimension)
        {
            obj.transform.parent = toDimension.gameObject.transform;
        }
        //else if (obj.transform.parent.gameObject.GetComponent<Dimension>() == toDimension)
        //{
        //    obj.transform.parent = fromDimension.gameObject.transform;
        //    SetLayerRecursively(obj.gameObject, fromDimension.layer);
        //}

        // If this is an FPS controller then make sure it goes through too.
        Transform parent = obj.transform.parent;
		if(parent != null && parent.GetComponent<CharacterController>()) {
			parent.gameObject.layer = toDimension.layer;
		}
	}

	public static void SwitchCameraRender(Camera camera, int fromDimensionLayer, int toDimensionLayer, Material dimensionSkybox) {
		CameraExtensions.LayerCullingShow (camera, toDimensionLayer);
		CameraExtensions.LayerCullingHide (camera, fromDimensionLayer);
		if (dimensionSkybox) {
			if (camera.GetComponent<Skybox> ()) {
				camera.GetComponent<Skybox> ().material = dimensionSkybox;	
			}
		}
	}

    public static void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }

}
