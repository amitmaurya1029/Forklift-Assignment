using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;


public class StartEngineDial : XRKnob
{
    const int start = 1;
    const int stop = 0;
    private bool isEngineStart = false;
    public static EventHandler<EventHandlerArgs> OnForkliftStart;
    private int lastValue = -1;

    void Start()
    {
        onValueChange.AddListener(EngineStart);
    }


    public void EngineStart(float val)
    {
        // first we selected and matched the value thane 

        int current = Mathf.RoundToInt(val);
        if ((current == start || current == stop) && current != lastValue)
        {
            bool isStart = current == start;

            OnForkliftStart?.Invoke(this, new EventHandlerArgs(isStart));
            Debug.Log("Start the engine : " + current);
            lastValue = current;
        }
         
    }
}

public class EventHandlerArgs : EventArgs
{
    private bool isEngineStart = false;

    public EventHandlerArgs(bool isStart)
    {
        isEngineStart = isStart;
    }
 
    public bool HasEngineStart()
    {
        return isEngineStart;
    }
}
