using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenralInteractable : VRTK.VRTK_InteractableObject
{
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
       
    }

    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
       
    }

    protected void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();     
    }
}
