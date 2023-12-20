using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShuttleRun : MonoBehaviour
{
    public Vector3[] points;
    private float speed;
    private bool forward;
    private int index = 0;

    void Start()
    {
        SetDefaultValues();
    }
    void Update()
    {
        Run();
    }
    private void Run()
    {
        if (forward)
        {
            if (index < points.Length - 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[index + 1], speed * Time.deltaTime);
                transform.LookAt(points[index + 1]);
                if (Vector3.Distance(transform.position, points[index + 1]) <= 0.5f)
                {
                    index++;
                }
                if (index == points.Length - 1)
                {
                    forward = false;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index - 1], speed * Time.deltaTime);
            transform.LookAt(points[index - 1]);
            if (Vector3.Distance(transform.position, points[index - 1]) <= 0.5f)
            {
                index--;
            }
            if (index == 0)
            {
                forward = true;
            }
        }
    }
    private void SetDefaultValues()
    {
        speed = 5f;
        forward = true;
    }
}
