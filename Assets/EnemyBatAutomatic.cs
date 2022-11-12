using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatAutomatic : MonoBehaviour
{
    //find player and move toward them
    //deal damage by touching
    Animator anim;
    Vector2 moveDir;
    EnemyStats es;
    bool isIdle = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
    }

    private void Start()
    {
        //set destination
        moveDir = PlayerStats.instance.transform.position - transform.position;
        moveDir.Normalize();
        Destroy(gameObject, 15f);
    }
    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += (Vector3)moveDir * es.moveSpeed * Time.deltaTime;
    }

    public void Hurt(float amount)
    {
        es.currentHitPoint -= amount;
        if (es.isKnockBack)
        {
            es.isKnockBack = false;
        }
        //alwasy knockback
        es.knockbackTime = 0.1f;
        Vector2 dir = transform.position - PlayerStats.instance.transform.position;
        dir.Normalize();

        if (es.currentHitPoint <= 0)
        {
            //drop exp and die
            Instantiate(es.expDrop, transform.position, Quaternion.identity);
            GameObject fxDead = Instantiate(es.deadFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(fxDead, 1f);
            Destroy(gameObject);
            PlayerStats.instance.totalEnemyKilled++;

            //play dead anim
        }
        else
        {
            //play hurt anim
        }
    }
    public void SetIdleAnimation()
    {
        isIdle = true;
    }
    public void SetSpeedAnimation(float amount)
    {
        es.moveSpeed = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet")) //deal dmg by dmg
        {
            Hurt(other.GetComponent<PlayerBullet>().damage);
            GameObject dmgPop = Instantiate(other.GetComponent<PlayerBullet>().dmgPopup, transform.position, Quaternion.identity) as GameObject;
            dmgPop.GetComponent<DamagePopup>().GetDamageNumber(other.GetComponent<PlayerBullet>().damage);
            GameObject fxHit = Instantiate(other.GetComponent<PlayerBullet>().fxWhenHit, transform.position, Quaternion.identity) as GameObject;
            Destroy(fxHit, 1f);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PlayerBulletSpecial")) //deal dmg by hp%
        {
            float percentHP = other.GetComponent<PlayerBullet>().SetSpecialDamageByHP();
            int specialDmg = (int)(percentHP * es.currentHitPoint);
            Hurt(specialDmg);
            GameObject dmgPop = Instantiate(other.GetComponent<PlayerBullet>().dmgPopup, transform.position, Quaternion.identity) as GameObject;
            dmgPop.GetComponent<DamagePopup>().GetDamageNumber(specialDmg);
            GameObject fxHit = Instantiate(other.GetComponent<PlayerBullet>().fxWhenHit, transform.position, Quaternion.identity) as GameObject;
            Destroy(fxHit, 1f);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.instance.Hurt(GameManager.instance.RandomDamage(es.attackDamage));
        }
    }
}
