using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectIceBall : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] GameObject hitFX;
    public PlayerBullet dmgZone;
    public float damage;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
        dmgZone.bulletSpeed = bulletSpeed;
    }

    private void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //with buff layer
        if (other.CompareTag("Enemy"))
        {
            GameObject fx = Instantiate(hitFX, transform.position, transform.rotation);
            Destroy(fx, 1f);
            Destroy(gameObject);
        }
    }
}
