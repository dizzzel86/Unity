using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    public Transform[] Penguin;
    private Vector3 TempPenguin_0;
    private bool isRun = false;
    private bool isRun2 = false;
    private bool isRun3 = false;
    private bool isRun4 = false;
    private bool isRun5 = false;
    void Start()
    {
        SetDefaulfValues();
    }
    void Update()
    {
        Run();

    }
    private void SetDefaulfValues()
    {
        isRun = true;
    }
    private void Run()
    {

        if (isRun)
        {
            TempPenguin_0 = Penguin[0].position;
            Penguin[0].position = Vector3.MoveTowards(Penguin[0].position, Penguin[1].position, Time.deltaTime * 4);
            Penguin[0].LookAt(Penguin[1]);
            if (Vector3.Distance(Penguin[0].position, Penguin[1].position) <= 0.1f)
            {
                isRun = false;
                isRun2 = true;
            }
        }
        if (isRun2)
        {
            Penguin[1].position = Vector3.MoveTowards(Penguin[1].position, Penguin[2].position, Time.deltaTime * 4);
            Penguin[1].LookAt(Penguin[2]);
            if (Vector3.Distance(Penguin[1].position, Penguin[2].position) <= 0.1f)
            {
                isRun2 = false;
                isRun3 = true;
            }
        }
        if (isRun3)
        {
            Penguin[2].position = Vector3.MoveTowards(Penguin[2].position, Penguin[3].position, Time.deltaTime * 4);
            Penguin[2].LookAt(Penguin[3]);
            if (Vector3.Distance(Penguin[2].position, Penguin[3].position) <= 0.1f)
            {
                isRun3 = false;
                isRun4 = true;
            }
        }
        if (isRun4)
        {
            Penguin[3].position = Vector3.MoveTowards(Penguin[3].position, Penguin[4].position, Time.deltaTime * 4);
            Penguin[3].LookAt(Penguin[4]);
            if (Vector3.Distance(Penguin[3].position, Penguin[4].position) <= 0.1f)
            {
                isRun4 = false;
                isRun5 = true;
            }
        }
        if (isRun5)
        {
            Penguin[4].position = Vector3.MoveTowards(Penguin[4].position, TempPenguin_0, Time.deltaTime * 4);
            Penguin[4].LookAt(Penguin[0]);
            if (Vector3.Distance(Penguin[4].position, Penguin[0].position) <= 0.1f)
            {
                isRun5 = false;
                SetDefaulfValues();
            }
        }
    }
}
