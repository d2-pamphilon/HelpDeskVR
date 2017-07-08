using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobing : MonoBehaviour
{

    float timer;
    bool forward;
    [SerializeField]
    private GameObject player;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        transform.LookAt(player.transform);
        timer += Time.deltaTime;

        if (timer >= 4.3)
        {
            forward = !forward;
            timer = 0;
        }
        if (forward)
            {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
            else
            {
            transform.Translate(-Vector3.forward * Time.deltaTime);
        }

    }
}
