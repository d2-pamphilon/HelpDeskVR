using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// commented bits are for scrolling backgrounds if needed
public class TextureSpinner : MonoBehaviour {
    public float speed = 0.0f;
    [SerializeField]
    private Material mat;

   // public Renderer rend;
    private Vector2 test;

    void Start()
    {
        //mat = GetComponent<Skybox>().material;
       // rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        mat.mainTextureOffset= test + new Vector2(0.1f * speed * Time.deltaTime, 0);
        // transform.Rotate(new Vector3(0, 1, 0) * speed);
        //rend.sharedMaterial.mainTextureOffset = test + new Vector2(0.1f * speed * Time.deltaTime, 0);
         test = mat.mainTextureOffset;
    }
}
