using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShuttleRun : MonoBehaviour
{

    public Vector3[] Robot;

    public GameObject Robot_1;
    public GameObject Robot_2;

    private Vector3 DefRobotPos;
    private bool forward;


    void Start()
    {
        SetDefaultVAlues();
    }
    void Update()
    {
        Run();
    }

    private void Run()
    {
        if (forward)
        {
            Vector3 direction = Robot_2.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 8f);
            transform.position += (Robot_2.transform.position - transform.position) * Time.deltaTime;

            if (Vector3.Distance(Robot_1.transform.position, Robot_2.transform.position) <= 0.5f)
            {
                forward = false;
            }

        }
        if (!forward)
        {
            Vector3 direction = DefRobotPos - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 8f);
            transform.position += (DefRobotPos - transform.position) * Time.deltaTime;

            if (Vector3.Distance(Robot_1.transform.position, DefRobotPos) <= 0.5f)
            {
                forward = true;
            }
        }


    }

    private void SetDefaultVAlues()
    {
        forward = true;
        DefRobotPos.Set(0.00f, 1.33f, 5.28f);
    }
}
