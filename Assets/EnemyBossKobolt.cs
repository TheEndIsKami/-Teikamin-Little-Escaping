using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossKobolt : MonoBehaviour
{
    //find player and move toward them
    //deal damage by touching
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    EnemyStats es;
    Animator anim;
    Rigidbody2D rb;
    Vector3 playerDistance;
    float attackCD;
    bool isIdle, isMove, isAttack;

    private void Start()
    {
        es = GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        attackCD = es.attackSpeed;

        BossHPBar.instance.UpdateHPBar(es.currentHitPoint, es.maxHitPoint);

    }
    //this kobolt will fire at player
    private void Update()
    {
        es.knockbackTime -= Time.deltaTime;
        if (es.knockbackTime >= 0) return;
        if (PlayerStats.instance == null) return;
        //check idle
        playerDistance = PlayerController.instance.transform.position - transform.position;
        if (playerDistance.sqrMagnitude <= (es.eyeRange) * (es.eyeRange)) //if player is in eyeRange then Engaged!
        {
            //if true, then this enemy must attack or moving
            if (playerDistance.sqrMagnitude <= (es.attackRange) * (es.attackRange)) { Fire(); }
            else { Move(); }
        }
        else //false when he can't see anyone
        {
            Idle();
        }

    }

    void Fire()
    {
        rb.velocity = Vector2.zero;
        attackCD -= Time.deltaTime;
        if (attackCD <= 0)
        {
            isAttack = true;
            isIdle = false;
            isMove = false;
            anim.SetBool("isAttack", isAttack);
            anim.SetBool("isIdle", isIdle);
            anim.SetBool("isMove", isMove);
            attackCD = es.attackSpeed;
        }
    }

    public void FireInAnimation()
    {
        //fire and set damage output
        GameObject koboltBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        koboltBullet.GetComponent<EnemyBossKoboltBullet>().SetDamage(es.attackDamage);
    }

    void Idle()
    {
        rb.velocity = Vector2.zero;
        isIdle = true;
        isMove = false;
        isAttack = false;
        anim.SetBool("isAttack", isAttack);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isMove", isMove);
    }
    void Move()
    {
        rb.velocity = es.moveSpeed * playerDistance.normalized;
        isAttack = false;
        isIdle = false;
        isMove = true;
        anim.SetBool("isAttack", isAttack);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isMove", isMove);
    }

    public void Hurt(float amount)
    {
        es.Hurt(amount);
        BossHPBar.instance.UpdateHPBar(es.currentHitPoint, es.maxHitPoint);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
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
    public void CameraShake()
    {
        Camera.main.GetComponent<CameraShake>().Play(0.1f, 0.1f);
    }
}
