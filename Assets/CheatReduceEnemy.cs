using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatReduceEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<EnemyStats>().isCanDestroy)
            {
                Destroy(collision.gameObject);
                PlayerStats.instance.totalEnemyKilled++;
            }
        }
    }
}
