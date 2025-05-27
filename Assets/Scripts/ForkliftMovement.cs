using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ForkliftMovement : MonoBehaviour
{
    public XRBaseInteractable leverInteractable;
    public Transform leverTransform;  
    public Transform forklift;
    public float moveSpeed = 3f;

    public float minAngle = -45f;
    public float maxAngle = 45f;
    public bool rotateOnZ = true; // true = use Z axis, false = use X

    private bool isHeld;
    private bool isEngineStart = false;


      void OnEnable()
    {
        StartEngineDial.OnForkliftStart += HasEngineStart;
        leverInteractable.selectEntered.AddListener(OnLeverGrabbed);
        leverInteractable.selectExited.AddListener(OnLeverReleased);
    }

  

    void Update()
    {

        if (isHeld && isEngineStart)
        {
            float rawAngle = rotateOnZ ? leverTransform.localEulerAngles.x : leverTransform.localEulerAngles.x;
            if (rawAngle > 180f) rawAngle -= 360f;

            float clampedAngle = Mathf.Clamp(rawAngle, minAngle, maxAngle);

            float t = Mathf.InverseLerp(minAngle, maxAngle, clampedAngle);

            float movementInput = t * 2f - 1f;

            Vector3 move = forklift.forward * movementInput * moveSpeed * Time.deltaTime;
            forklift.position += move;
            }
       
    }



    private void HasEngineStart(object sender, EventHandlerArgs eventHandlerArgs)
    {
        isEngineStart = eventHandlerArgs.HasEngineStart();
    }

    void OnLeverGrabbed(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    void OnLeverReleased(SelectExitEventArgs args)
    {
        isHeld = false;
    }
}
