using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public Rigidbody body;
    private Rigidbody _rigidbody;
    private float force;
    public float boomForce;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        force = 50f;
        Vector3 direction = new Vector3(0, 0, -1); // направление удара
        body.AddForce(direction * force, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out _rigidbody))
        {
            Vector3 direction = collision.transform.position - transform.position;
            _rigidbody.AddForce(direction * boomForce, ForceMode.Impulse);
        }
    }
}
