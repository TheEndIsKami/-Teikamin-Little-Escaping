using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContinueDMG : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().Hurt(0.1f * PlayerStats.instance.maxHitPoint);
        }
    }
}
