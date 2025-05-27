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

    private bool isEngineStart = false;


    void Start()
    {
        StartEngineDial.OnForkliftStart += PlayEngineStartSound;
        LiftLiver.OnleverLift += PlayeLiftUpAndDownSound;
    }

    private void PlayEngineStartSound(object sender, EventHandlerArgs e)
    {
        isEngineStart = e.HasEngineStart();

        if (isEngineStart)
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

    private void PlayeLiftUpAndDownSound(bool liftState)
    {
        if (liftState)
            PlaySound(liftDown);
        else
            PlaySound(liftUp);
    }

    // public void PlayLiftUpSound()
    // {
    //     PlaySound(liftUp);
    // }

    // public void PlayLiftDownSound()
    // {
    //     PlaySound(liftDown);
    // }

    private void PlaySound(AudioClip audioClip)
    {
        if (!isEngineStart) { return; }
        forkliftLift.clip = audioClip;
        forkliftLift.Play();
    }
 
}
