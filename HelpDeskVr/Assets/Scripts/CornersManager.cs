using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornersManager : MonoBehaviour {

    [SerializeField]
    GameObject CornerNE;
    [SerializeField]
    GameObject CornerNW;
    [SerializeField]
    GameObject CornerSE;
    [SerializeField]
    GameObject CornerSW;

    [SerializeField]
    GameObject CameraRig;

    [SerializeField]
    Vector3[] vertices;

    // Use this for initialization
    void Start () {
        var rect = new Valve.VR.HmdQuad_t();
        SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect);

        vertices = new Vector3[4];
        vertices[0] = new Vector3(rect.vCorners0.v0, rect.vCorners0.v1, rect.vCorners0.v2);
        vertices[1] = new Vector3(rect.vCorners1.v0, rect.vCorners1.v1, rect.vCorners1.v2);
        vertices[2] = new Vector3(rect.vCorners2.v0, rect.vCorners2.v1, rect.vCorners2.v2);
        vertices[3] = new Vector3(rect.vCorners3.v0, rect.vCorners3.v1, rect.vCorners3.v2);

        vertices[0] += CameraRig.transform.position;
        vertices[1] += CameraRig.transform.position;
        vertices[2] += CameraRig.transform.position;
        vertices[3] += CameraRig.transform.position;

    }

    //// Update is called once per frame
    //void Update () {

    //}
}
