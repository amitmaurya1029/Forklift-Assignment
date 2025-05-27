using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{
    [SerializeField] private Transform target;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Carton>(out Carton component))
        {
            Transform carton = collision.transform;
            carton.SetParent(target);
            carton.GetComponent<Rigidbody>().isKinematic = true;
            carton.localPosition = Vector3.zero;

            Debug.Log("collided elemnet name : " + collision.transform.name);
        }
        else
        {
            Debug.Log("collided elemnet name : other carton type");
        }
    }
    




}
