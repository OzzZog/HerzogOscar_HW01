using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if(enemyBase != null)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }
    }
}
