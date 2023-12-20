using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    public Transform[] Penguin;
    private int index;
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
        index = 0;
    }
    private void Run()
    {
        if (index < Penguin.Length - 1)
        {
            Penguin[index].position = Vector3.MoveTowards(Penguin[index].position, Penguin[index + 1].position, Time.deltaTime * 4);
            Penguin[index].LookAt(Penguin[index + 1]);
            if (Vector3.Distance(Penguin[index].position, Penguin[index + 1].position) <= 0.1f)
            {
                index++;
            }
        }
        else
        {
            Penguin[index].position = Vector3.MoveTowards(Penguin[index].position, Penguin[0].position, Time.deltaTime * 4);
            Penguin[index].LookAt(Penguin[0]);

            if (Vector3.Distance(Penguin[index].position, Penguin[0].position) <= 0.1f)
            {
                index = 0;
            }
        }
    }
}
