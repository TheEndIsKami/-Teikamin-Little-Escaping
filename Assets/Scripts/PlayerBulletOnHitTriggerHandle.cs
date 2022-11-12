using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletOnHitTriggerHandle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.onHitTrigger = true;
        }
    }
}
