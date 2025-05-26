using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkliftAnimController : XRLever
{
    //[SerializeField] private XRSlider xRLiver;

    void Start()
    {
        onLeverActivate.AddListener(fun2);
        onLeverActivate.AddListener(fun);
    }


    void Update()
    {

    }

    private void fun()
    {
        Debug.Log("lift: up");
    }

    
    private void fun2()
    {
        Debug.Log("lift: down");
    }
}
