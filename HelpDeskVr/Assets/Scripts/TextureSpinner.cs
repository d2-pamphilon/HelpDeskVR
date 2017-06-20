using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// commented bits are for scrolling backgrounds if needed
public class TextureSpinner : MonoBehaviour {
    public float speed = 0.0f;
   // public Renderer rend;
    //private Vector2 test;
    // Use this for initialization
    void Start()
    {
       // rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * speed);
        //rend.sharedMaterial.mainTextureOffset = test + new Vector2(0.1f * speed * Time.deltaTime, 0);
       // test = rend.material.mainTextureOffset;
    }
}
