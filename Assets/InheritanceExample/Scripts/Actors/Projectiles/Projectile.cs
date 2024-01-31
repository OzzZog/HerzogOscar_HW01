using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 deltaPosition = transform.forward * _speed;
        _rb.MovePosition(_rb.position + deltaPosition);
    }
}
