using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossSlime : MonoBehaviour
{
    //find player and move toward them
    //deal damage by touching
    Animator anim;
    Vector2 moveDir;
    Rigidbody2D rb;
    EnemyStats es;
    bool isIdle = true;

    //game feel


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        es = GetComponent<EnemyStats>();
    }

    private void Start()
    {
        BossHPBar.instance.UpdateHPBar(es.currentHitPoint, es.maxHitPoint);

        //game feel
        
    }
    private void Update()
    {
        es.knockbackTime -= Time.deltaTime;
        if (es.knockbackTime >= 0) return;
        Move();
    }

    private void Move()
    {
        if (PlayerStats.instance == null) return;
        moveDir = PlayerStats.instance.transform.position - transform.position;
        moveDir.Normalize();
        rb.velocity = moveDir * es.moveSpeed;
        anim.SetBool("isMove", true);
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

    public void CameraShake()
    {
        Camera.main.GetComponent<CameraShake>().Play(0.27f, 0.1f);
    }

    public void SetSpeedAnimation(float amount)
    {
        es.moveSpeed = amount;
    }

    public void Hurt(float amount)
    {
        es.currentHitPoint -= amount;
        if (es.isKnockBack)
        {
            rb.velocity = Vector2.zero;
            es.knockbackTime = 0.1f;
            Vector2 dir = transform.position - PlayerStats.instance.transform.position;
            dir.Normalize();
            rb.AddForce(dir * es.knockbackStrengh, ForceMode2D.Impulse);

            es.isKnockBack = false;
        }

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
            rb.velocity = Vector2.zero;
            GetComponent<Animator>().SetTrigger("hurt");
        }
        BossHPBar.instance.UpdateHPBar(es.currentHitPoint, es.maxHitPoint);
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
