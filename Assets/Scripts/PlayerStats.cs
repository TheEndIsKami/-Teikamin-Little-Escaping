using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    [Header("Player Basic Stats")]
    public int level = 1;
    public float hitPoint = 100f;
    public float maxHitPoint = 100f;
    public float mana = 0f;
    public float normalAttackDamage = 5f;
    public float bonusAtkDmg;
    public float totalDmg;
    public float totalDmgMultiple;
    public int totalEnemyKilled;

    [Header("Player Basic Attack")]
    public float attackSpeed = 2f;
    public float attackSpeedMutilple = 1f; //chu y as cang thap cang manh

    [Header("Set Player Range")]
    public float maxRange;
    public float minRange;

    [Header("Indicator UI")]
    public GameObject indicator;
    public Slider hpBar;

    [Header("FX")]
    [SerializeField] GameObject dmgPopupPlayer;
    SpriteRenderer sr;
    [SerializeField] float invincibleTime = 1f;
    float invincibleTimeCD;

    [Header("PlayerPrefs")]
    public static int soulGet = 0;
    //atk
    public static float normalATK = 10f;
    public static int levelNormalATK = 1;
    //hp
    public static float normalMaxHP = 50f;
    public static int levelNormalMaxHP = 1;
    //spd
    public static float normalSpd = 2.5f;
    public static int levelNormalSpd = 1;

    public int currentRunSoulGet = 0;
    private void Awake()
    {
        instance = this;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        hitPoint = maxHitPoint;
        hpBar.maxValue = maxHitPoint;
        hpBar.value = hitPoint;
        invincibleTimeCD = invincibleTime;
    }

    private void Update()
    {
        totalDmg = (normalAttackDamage + bonusAtkDmg) * totalDmgMultiple;

        invincibleTimeCD -= Time.deltaTime;
        if (invincibleTimeCD > 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
    public void Hurt(float amount)
    {
        if (invincibleTimeCD <= 0)
        {
            hitPoint -= amount;
            UpdateHPBar();
            GameObject dmgPop = Instantiate(dmgPopupPlayer, transform.position, Quaternion.identity) as GameObject;
            dmgPop.GetComponent<DamagePopup>().GetDamageNumber(amount);

            if (hitPoint <= 0)
            {
                UIManager.instance.DeadScreen();
                gameObject.SetActive(false);

                //update save game
                PlayerPrefs.SetInt("Soul", soulGet + currentRunSoulGet);
                PlayerPrefs.Save();
            }

            invincibleTimeCD = invincibleTime;
        }
    }

    public void UpdateHPBar()
    {
        hpBar.value = hitPoint;
    }
    public void Heal(float amount)
    {
        hitPoint += amount;
        if (hitPoint >= maxHitPoint) hitPoint = maxHitPoint;
        hpBar.value = hitPoint;
        //add heal popup
    }
}
