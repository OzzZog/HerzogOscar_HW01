using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnLoc;
    [SerializeField] private GameObject _projectileToSpawn;

    public void AttemptFire()
    {

        Fire();
    }

    public void Fire()
    {
        Instantiate(_projectileToSpawn, 
            _projectileSpawnLoc.position, transform.rotation);
    }
}
