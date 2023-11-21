using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleRun : MonoBehaviour
{

    public Transform[] Robot;
    private Vector3 TempRobotPos;
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
            
            Robot[0].position = Vector3.MoveTowards(Robot[0].position, Robot[1].position, Time.deltaTime * 4);
            Robot[0].LookAt(Robot[1].position);
            if (Vector3.Distance(Robot[0].position, Robot[1].position) <= 0.5f)
            {
                forward = false;
            }
            
        }
        if (!forward)
            {
                Robot[0].position = Vector3.MoveTowards(Robot[0].position, DefRobotPos, Time.deltaTime * 4);
                Robot[0].LookAt(DefRobotPos);
                if (Vector3.Distance(Robot[0].position, DefRobotPos) <= 0.5f)
                {
                    SetDefaultVAlues();
                }
            }

    }

    private void SetDefaultVAlues()
    {
        forward = true;
       DefRobotPos.Set(0.00f, 1.33f, 5.28f);
    }
}
