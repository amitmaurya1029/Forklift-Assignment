using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource forkliftEngine;
    [SerializeField] private AudioSource forkliftLift;
    [SerializeField] private AudioClip liftUp;
    [SerializeField] private AudioClip liftDown;
    

    void Start()
    {
        StartEngineDial.OnForkliftStart += PlayEngineStartSound;
    }

    private void PlayEngineStartSound(object sender, EventHandlerArgs e)
    {
        if (e.HasEngineStart())
        {
            forkliftEngine.Play();
            Debug.Log("Engine Sound start : active");
        }
        else
        {
            forkliftEngine.Stop();
            Debug.Log("Engine Sound start : disable");
        }
    }


    public void PlayLiftUpSound()
    {
        forkliftLift.clip = liftUp;
        forkliftLift.Play();
    }

    
    public void PlayLiftDownSound()
    {
        forkliftLift.clip = liftDown;
        forkliftLift.Play();
    }
 
}
