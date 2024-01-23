using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public Rigidbody ball;
    private float force;//���� �����

    void Start()
    {
        OnCollisionEnter3D();
    }

    void OnCollisionEnter3D()
    {
        force = 80.0f;
        Vector3 direction = new Vector3(1, 0); // ����������� �����
        ball.AddForce(direction * force, ForceMode.Impulse);
    }
}
