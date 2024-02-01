using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    private float duration = 1f;

    protected override void OnHit()
    {
        
        StartCoroutine(StopMoving());
        
    }
    
    private IEnumerator StopMoving()
    {
        MoveSpeed = 0.0f;
        yield return new WaitForSeconds(duration);
        MoveSpeed = 0.05f;
    }
}
