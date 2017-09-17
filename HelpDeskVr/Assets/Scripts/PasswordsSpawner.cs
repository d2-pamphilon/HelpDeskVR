using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordsSpawner : MonoBehaviour {

    string[] passwords = new string[10000];
    float timePassed;

    [SerializeField]
    GameObject passwordPrefab;
    [SerializeField]
    float timeBetweenPasswords;
    [SerializeField]
    Transform centerPoint;
    [SerializeField]
    float minRadius;
    [SerializeField]
    float maxRadius;

    [SerializeField]
    int minTextSize;
    [SerializeField]
    int maxTextSize;

    [SerializeField]
    int lastPassword;

    int counter = 0;

    // Use this for initialization
    void Start () {
        TextAsset passData = Resources.Load("10k_most_common") as TextAsset;
        passwords = passData.text.Split('\n'); //C#
        CreatePassword(0);
    }
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed > timeBetweenPasswords && counter < 100)
        {
            counter++;
            timePassed = 0.0f;
            int index = Random.Range(0, lastPassword);
            if (timeBetweenPasswords > 1)
            {
                timeBetweenPasswords -= timeBetweenPasswords / 100;
            }
            CreatePassword(index);
        }
	}

    private void CreatePassword(int index)
    {
        GameObject newPass = Instantiate(passwordPrefab);
        var txt = newPass.GetComponent<TMPro.TextMeshPro>();
        txt.text = passwords[index];
        txt.color = Random.ColorHSV();
        txt.fontSize = Random.Range(minTextSize, maxTextSize);
        //txt.fontStyle = (FontStyle)(Random.Range(0, 4));
        Vector3 dir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        dir.Normalize();
        dir *= Random.Range(minRadius, maxRadius);
        Vector3 pos = centerPoint.position + dir;
        newPass.transform.position = pos;
        newPass.transform.LookAt(centerPoint);
        dir.Normalize();
        dir *= 10;
        newPass.GetComponent<PasswordMovement>().target = centerPoint.position + dir;
        newPass.GetComponent<PasswordMovement>().centerPoint = centerPoint;
        newPass.transform.SetParent(transform);
        newPass.layer = gameObject.layer;
    }
}
