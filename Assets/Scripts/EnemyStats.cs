using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject expDrop;
    public float strenghMutiple = 1;
    public float maxHitPoint = 10f;
    public float currentHitPoint;

    public float attackRange;
    public float eyeRange = 10f;
    public float attackDamage;
    public float attackSpeed = 2f;
    public float attackSpeedCD;
    public float attackCritChance = 0.1f;
    public float attackCritDamage = 1.5f;

    public float moveSpeed = 5f;
    float moveSpeedBase;
    public float idleTime = 1f;
    public float idleTimeCD;
    public float knockbackTime = 0.1f;
    public float knockbackStrengh = 5f;

    public bool isKnockBack = false;

    public int level = 1; //for boss only
    public float selfDestructTime = 5f; //for normal enemy Only
    public bool isCanDestroy;
    public bool isBoss;
    [Header ("Buff Config")]
    float buffDur;
    float buffDurCD;

    //buff apply on
    public bool isSlow;
    public bool isPurify;
    int purifyStack;
    float purifyCD;

    [Header("Game Feel")]
    public GameObject deadFX;
    [SerializeField] GameObject dmgPopUpPurifyEffect;


    Rigidbody2D rb;

    private void Awake()
    {
        attackSpeedCD = attackSpeed;
        currentHitPoint = maxHitPoint;
        idleTimeCD = idleTime;
        moveSpeedBase = moveSpeed;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        strenghMutiple = (1 + (float)GameManager.instance.gameTime / 600f);
        //strenght mutilple if have
        attackDamage *= strenghMutiple;
        maxHitPoint *= strenghMutiple;
        currentHitPoint = maxHitPoint;
        GameManager.instance.totalEnemyHasSpawned++;
    }
    private void Update()
    {
        if (PlayerStats.instance == null) return;
        Vector2 dir = PlayerStats.instance.transform.position - transform.position;
        if (dir.sqrMagnitude <= 80)
        {
            if (!isBoss) isCanDestroy = true;
        }
    }
    private void LateUpdate()
    {
        buffDurCD -= Time.deltaTime;
        if (isSlow)
        {
            moveSpeed = moveSpeedBase/2f;
            if (buffDurCD >= 0) return;
            isSlow = false;
            moveSpeed = moveSpeedBase;
        }
        if (isPurify)
        {
            purifyCD -= Time.deltaTime;
            if (purifyCD <= 0)
            {
                if (purifyStack > PlayerController.instance.maxStackBulletOfLight) purifyStack = PlayerController.instance.maxStackBulletOfLight;
                Hurt(3f * purifyStack, false);
                GameObject dmgPop = Instantiate(dmgPopUpPurifyEffect, transform.position, Quaternion.identity) as GameObject;
                dmgPop.GetComponent<DamagePopup>().GetDamageNumber(3f * purifyStack);
                purifyCD = 1f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Buff")) //take buff
        {
            int buffGet = (int)other.GetComponent<BuffAdder>().thisBuff;

            switch (buffGet)
            {
                case 0: isSlow = true; buffDur = other.GetComponent<BuffAdder>().buffType.buffDur; buffDurCD = buffDur; break;
                case 1: isPurify = true; purifyStack += 1; break;
                default: isSlow = true; break;
            }
        }
    }
    public void Hurt(float amount, bool isHurtAnim = true)
    {
        currentHitPoint -= amount;
        if (isKnockBack)
        {
            rb.velocity = Vector2.zero;
            knockbackTime = 0.1f;
            Vector2 dir = transform.position - PlayerStats.instance.transform.position;
            dir.Normalize();
            rb.AddForce(dir * knockbackStrengh, ForceMode2D.Impulse);
            isKnockBack = false;
        }
        //alwasy knockback
        if (!isBoss)
        {
            rb.velocity = Vector2.zero;
            knockbackTime = 0.1f;
            Vector2 dir = transform.position - PlayerStats.instance.transform.position;
            dir.Normalize();
            rb.AddForce(dir * knockbackStrengh, ForceMode2D.Impulse);
        }

        if (currentHitPoint <= 0)
        {
            //drop exp and die
            Instantiate(expDrop, transform.position, Quaternion.identity);
            GameObject fxDead = Instantiate(deadFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(fxDead, 1f);
            Destroy(gameObject);
            PlayerStats.instance.totalEnemyKilled++;
            PlayerStats.instance.currentRunSoulGet++;
            //play dead anim
        }
        else if (isHurtAnim)
        {
            //play hurt anim
            GetComponent<Animator>().SetTrigger("hurt");
        }
    }
}
