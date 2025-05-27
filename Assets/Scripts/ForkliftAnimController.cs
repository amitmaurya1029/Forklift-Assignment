using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkliftAnimController : MonoBehaviour
{
    private Animator animator;
    private string IsLifting = "IsLifting";
    private bool isEngineStart = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartEngineDial.OnForkliftStart += HasForkliftStart;
        LiftLiver.OnleverLift += PlayAnimation;
    }

    private void HasForkliftStart(object sender, EventHandlerArgs e)
    {
        isEngineStart = e.HasEngineStart();
    }

    private void PlayAnimation(bool liftState)
    {
        if (isEngineStart)
        {
            if (liftState)
                LiftDown();
            else
                LiftUp();
        }
  
    }

    public void LiftUp()
    {
        animator.SetBool(IsLifting, true);
        Debug.Log("lift: up");
    }


    public void LiftDown()
    {
        animator.SetBool(IsLifting, false);
        Debug.Log("lift: down");
    }

    


}
