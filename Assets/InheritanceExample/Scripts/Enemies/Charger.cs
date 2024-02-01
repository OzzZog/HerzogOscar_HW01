using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] RapidFire rapidFire;

    protected override void OnHit()
    {
        // increase speed when hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        Instantiate(rapidFire, transform.position, Quaternion.identity);
        base.Kill();
    }
}
