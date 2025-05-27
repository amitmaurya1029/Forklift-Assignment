using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    void Start()
    {
        StartEngineDial.OnForkliftStart += PlayEngineStartSound;
    }

    private void PlayEngineStartSound(object sender, EventHandlerArgs e)
    {
        if (e.HasEngineStart())
        {
            Debug.Log("Engine Sound start : active");
        }
        else
        {
            Debug.Log("Engine Sound start : disable");
        }
    }

 
}
