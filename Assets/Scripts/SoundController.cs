using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource forkliftSound;
    void Start()
    {
        StartEngineDial.OnForkliftStart += PlayEngineStartSound;
    }

    private void PlayEngineStartSound(object sender, EventHandlerArgs e)
    {
        if (e.HasEngineStart())
        {
            forkliftSound.Play();
            Debug.Log("Engine Sound start : active");
        }
        else
        {
            forkliftSound.Stop();
            Debug.Log("Engine Sound start : disable");
        }
    }

 
}
