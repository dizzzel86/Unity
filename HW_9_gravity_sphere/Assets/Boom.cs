using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float Timer;
    public float Power;
    public float Radius;
    public float Speed;
    void Start()
    {

    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            BigBadaBoom();
        }
    }

    void BigBadaBoom()
    {
        Rigidbody[] objects = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody obj in objects)
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < Radius)
            {
                Vector3 direction = obj.transform.position - transform.position;
                obj.AddForce(direction * Power * (Radius - Vector3.Distance(transform.position, obj.transform.position)), ForceMode.Impulse);
                Debug.Log("Boom");
            }
        }
        Timer = 3;
    }

}
