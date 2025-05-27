using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carton : MonoBehaviour
{
    private Transform parent;
    
    public void SetParent(Transform parent)
    {
        this.parent = parent;
    }
}
