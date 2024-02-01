using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    TurretController turretController;

    private void Awake()
    {
        turretController = FindObjectOfType<TurretController>();
    }

    protected override void OnHit()
    {
        PowerUp();
    }

    protected override void PowerUp()
    {
        turretController.FireCooldown = 0.25f;
        Invoke("PowerDown", PowerupDuration);
    }

    protected override void PowerDown()
    {
        turretController.FireCooldown = 0.5f;
    }
}
