using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] protected float PowerupDuration;
    [SerializeField] private AudioClip _powerupSound;

    protected abstract void OnHit();
    protected abstract void PowerUp();
    protected abstract void PowerDown();


    protected Collider COLLIDER;
    protected MeshRenderer MESHRENDERER;

    private void Start()
    {
        COLLIDER = GetComponent<Collider>();
        MESHRENDERER = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {           
            AudioHelper.PlayClip2D(_powerupSound, 1, .1f);
            OnHit();

            MESHRENDERER.enabled = false;
            COLLIDER.enabled = false;

            Invoke("DestroyItself", PowerupDuration);
        }
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
