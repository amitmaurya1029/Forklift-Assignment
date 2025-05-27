using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;


public class LiftLiver : XRLever
{
    public static event Action<bool> OnleverLift;

    void Start()
    {
        onLeverActivate.AddListener(InvokeActiveLeverEvent);
        onLeverDeactivate.AddListener(InvokeDeActiveLeverEvent);

    }


    private void InvokeActiveLeverEvent()
    {
        OnleverLift?.Invoke(true);
    }

     private void InvokeDeActiveLeverEvent()
    {
        OnleverLift?.Invoke(false);
    }

    
}
