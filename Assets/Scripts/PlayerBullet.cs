using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float damage;
    public float percentHPdmg;

    public GameObject dmgPopup;
    public GameObject fxWhenHit;
    Rigidbody2D rb;

    bool isKnockBack = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    public void SetDamage(float dmg)
    {
        PlayerStats.instance.mana += 10f;
        damage = GameManager.instance.RandomDamage(dmg);
    }
    public float SetSpecialDamageByHP()
    {
        return percentHPdmg;
    }
    public void SetKnockBackCondition(bool isKnockBack)
    {
        this.isKnockBack = isKnockBack;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && isKnockBack)
        {
            other.GetComponent<EnemyStats>().isKnockBack = isKnockBack;
        }
    }
}
