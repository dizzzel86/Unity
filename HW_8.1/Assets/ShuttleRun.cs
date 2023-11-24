using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShuttleRun : MonoBehaviour
{
    public Vector3[] points;
    private float speed;
    private bool forward;

    public GameObject Robot;

    private int index;

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
                Vector3 direction = points[index + 1] - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 8f);
                transform.position = Vector3.MoveTowards(transform.position, points[index + 1], speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, points[index + 1]) <= 0.5f)
                {
                    forward = false;
                    index++;
                }
            }
        }
        else
        {
            if (index == points.Length - 1)
            {
                Vector3 direction = points[index - 1] - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 8f);
                transform.position = Vector3.MoveTowards(transform.position, points[index - 1], speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, points[index - 1]) <= 0.5f)
                {
                    forward = true;
                    index--;
                }
            }
        }
    }
    private void SetDefaultValues()
    {
        points[1].Set(0.00f, 0f, -10.26f);
        speed = 5f;
        forward = true;
    }
}
