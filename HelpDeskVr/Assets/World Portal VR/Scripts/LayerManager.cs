/*
 * Copyright (c) 2017 VR Stuff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager {
	public  static LayerManager instance = null;  

	public Dictionary<int, string> definedLayers;
	private static int totalLayerNum = 31;

	public static LayerManager Instance() {
		if (instance == null) {
			instance = new LayerManager ();
			instance.definedLayers = new Dictionary<int, string>();
		}
		return instance;
	}

	public int CreateLayer(string name) {
        int layerNum = findFirstFreeLayer();
        if (layerNum == 0)
        {
            return 0;
        }
		definedLayers[layerNum] = name;

        // Make physics independant
        foreach (var layer in definedLayers)
        {
            foreach (var layer2 in definedLayers)
            {
                if (layer.Key == layer2.Key) continue;
                Physics.IgnoreLayerCollision (layer.Key, layer2.Key);
            }
        }
        //for (int i = 0; i < definedLayers.Count; i++) {
		//	for (int j = 0; j < definedLayers.Count; j++) {
		//		if (i == j) continue;
		//		Physics.IgnoreLayerCollision (totalLayerNum - i - 1, totalLayerNum - j - 1);
		//	}
		//}

		return layerNum;
	}

    public void RemoveLayer(int index)
    {
        definedLayers.Remove(index);
    }

    public int findFirstFreeLayer()
    {
        for (int i = totalLayerNum; i > 13; i--)
        {
            if (!definedLayers.ContainsKey(i))
            {
                return i;
            }
        }
        return 0;
    }
}