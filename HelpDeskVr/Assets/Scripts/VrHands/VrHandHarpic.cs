using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrHandHarpic : VRTK.VRTK_InteractableObject
{
    public VRTK.VRTK_ControllerActions controllerActions;
    private float impactMagnifier = 120f;
    private float collisionForce = 0f;
    private float maxCollisionForce = 4000f;

    public void Awake()
    {
        controllerActions = gameObject.GetComponent<VRTK.VRTK_ControllerActions>();
    }
    public float CollisionForce()
    {
        return collisionForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (controllerActions)
        {
            collisionForce = VRTK.VRTK_DeviceFinder.GetControllerVelocity(controllerActions.gameObject).magnitude * impactMagnifier;
            var hapticStrength = collisionForce / maxCollisionForce;
            controllerActions.TriggerHapticPulse(hapticStrength, 0.5f, 0.01f);
        }
        else
        {
            collisionForce = collision.relativeVelocity.magnitude * impactMagnifier;
        }
    }
}
