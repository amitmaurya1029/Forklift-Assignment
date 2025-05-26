using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkliftAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string IsLifting = "IsLifting";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {

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
