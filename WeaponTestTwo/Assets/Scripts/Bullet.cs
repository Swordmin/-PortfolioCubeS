using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = transform.TransformDirection(Vector3.forward * _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _speed = 0;
        _rb.mass = 100000;
    }
}
