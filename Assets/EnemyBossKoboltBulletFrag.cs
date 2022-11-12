using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossKoboltBulletFrag : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject dmgPopup;

    float damage;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        rb.velocity = transform.up * speed;
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().Hurt(damage);
            Destroy(gameObject);
        }
    }
}
