using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour {

    public static bool IsPlayerLookingAt(GameObject objB)
    {
        GameObject objA = GameManager.Instance.mainCamera.gameObject;
        Vector3 dirFromAtoB = (objB.transform.position - objA.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, objA.transform.forward);

        return (dotProd > 0.5);
    }
}
