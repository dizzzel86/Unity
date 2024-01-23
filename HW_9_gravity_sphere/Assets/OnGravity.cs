using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGravity : MonoBehaviour
{

    void Start()
    {
        ;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody[] objects = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = false;
            Debug.Log("Gravity = false");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody[] objects = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = true;
            Debug.Log("Gravity = true");
        }
    }
}
