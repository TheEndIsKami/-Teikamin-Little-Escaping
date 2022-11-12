using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlime : MonoBehaviour
{
    //find player and move toward them
    //deal damage by touching
    Animator anim;
    Vector2 moveDir;
    Rigidbody2D rb;
    EnemyStats es;
    bool isIdle = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
    }

    private void Update()
    {
        es.knockbackTime -= Time.deltaTime;
        if (es.knockbackTime >= 0) return;
        if (PlayerStats.instance == null) return;
        Idle();
        Move();
        Attack();

        //set bool animation
        anim.SetBool("isIdle", isIdle);
    }

    void Attack()
    {
        es.attackSpeedCD -= Time.deltaTime;
        Vector2 range = PlayerStats.instance.transform.position - transform.position;
        //stop in range then attack
        if (range.sqrMagnitude <= es.attackRange*es.attackRange && es.attackSpeedCD <= 0)
        {
            rb.velocity = Vector2.zero;
            es.attackSpeedCD = es.attackSpeed;

            //attack
            anim.SetTrigger("attack");
        }
    }
    private void Move()
    {
        if (!isIdle)
        {
            moveDir = PlayerStats.instance.transform.position - transform.position;
            moveDir.Normalize();
            rb.velocity = moveDir * es.moveSpeed;
        }
    }
    public void Idle()
    {
        if (isIdle)
        {
            rb.velocity = Vector2.zero;

            es.idleTimeCD -= Time.deltaTime;
            if (es.idleTimeCD <= 0)
            {
                es.idleTimeCD = es.idleTime;
                isIdle = false;
                anim.SetTrigger("move");
            }
        }
    }
    public void Hurt(float amount)
    {
        es.Hurt(amount);
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
