using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crawler : EnemyBase
{
    protected override void OnHit()
    {
        
    }

    public override void Kill()
    {
        //TODO put code you want to happen before disable here

        // this runs the base method AND what's above it here
        base.Kill();
    }
}
