using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float _projectileLifetime = 4;

    private void Awake()
    {
        Destroy(gameObject, _projectileLifetime);
    }
}
