using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{
    [SerializeField] private XRKnob engineStartKnob;

    void Start()
    {
        engineStartKnob.onValueChange.AddListener(EngineStart);
    }

    private void EngineStart(float val)
    {
        Debug.Log("Start the engine : " + val);
    }
   
}
