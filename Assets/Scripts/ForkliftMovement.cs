using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ForkliftMovement : MonoBehaviour
{
    public XRBaseInteractable leverInteractable;
    public Transform leverTransform;  // Drag the XR Lever's rotating part here
    public Transform forklift;
    public float moveSpeed = 3f;

    public float minAngle = -45f;
    public float maxAngle = 45f;
    public bool rotateOnZ = true; // true = use Z axis, false = use X

    private bool isHeld;

    void Update()
    {

        if (isHeld)
        {
            // Read lever's local rotation angle (you may need to adjust this depending on axis)
            float rawAngle = rotateOnZ ? leverTransform.localEulerAngles.x : leverTransform.localEulerAngles.x;

            // Fix Unity's 0–360 wraparound to -180–180
            if (rawAngle > 180f) rawAngle -= 360f;

            // Clamp to range
            float clampedAngle = Mathf.Clamp(rawAngle, minAngle, maxAngle);

            // Normalize angle between min and max => returns 0–1
            float t = Mathf.InverseLerp(minAngle, maxAngle, clampedAngle);

            // Convert to -1 to 1 range
            float movementInput = t * 2f - 1f;

            // Apply movement
            Vector3 move = forklift.forward * movementInput * moveSpeed * Time.deltaTime;
            forklift.position += move;
            }
       
    }


     void OnEnable()
    {
        leverInteractable.selectEntered.AddListener(OnLeverGrabbed);
        leverInteractable.selectExited.AddListener(OnLeverReleased);
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
