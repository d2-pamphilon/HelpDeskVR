using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PubLogCanvasController : MonoBehaviour {

    public Sprite[] images;

    public Image monitor;

    public float timer;
    public float timeBetweenSlides = 1.0f;
    public int currentImage = 0;

	// Use this for initialization
	void Start () {
        monitor = transform.parent.GetComponentInChildren<Image>();
        timer = 0.0f;
        timeBetweenSlides = Random.Range(2.0f, 4.0f);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > timeBetweenSlides)
        {
            timer = 0.0f;
            currentImage++;
            if (currentImage == images.Length)
            {
                currentImage = 0;
            }
            monitor.sprite = images[currentImage];
        }
	}
}
