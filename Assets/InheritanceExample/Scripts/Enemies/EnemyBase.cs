using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] protected float MoveSpeed = .05f;

    protected abstract void OnHit();

    protected Rigidbody RB { get; private set; }

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        Vector3 moveDelta = transform.forward * MoveSpeed;
        RB.MovePosition(RB.position + moveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            _health -= 1;
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            if (_health <= 0)
            {
                Kill();
            }
        }
    }

    public virtual void Kill()
    {
        AudioHelper.PlayClip2D(_deathSound, 1, .1f);
        gameObject.SetActive(false);
    }
}
