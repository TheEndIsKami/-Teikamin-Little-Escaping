using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject playerStaff;
    public GameObject firePoint;

    public GameObject[] bullets;
    public GameObject bulletOfLight;
    
    //anim
    Animator anim;
    public bool isIdle;

    //other
    float minRange;
    float maxRange;
    public GameObject closestEnemy;

    //player attack handle
    float attackSpeed, attackSpeedCD;

    //for Item spawner
    public GameObject fireStaffFireBall;
    public GameObject bootsOfSpeedFire;
    public GameObject itemFX_windWhisper;
    public GameObject itemFX_bowOfDevil;
    public GameObject itemFX_maskOfLife;
    public GameObject itemFX_iceBall;
    public GameObject itemFX_iceBall_Fragment;
    public GameObject itemFX_fallen_Sky;
    public GameObject itemFX_Sword_Of_Light;

    public bool isBulletOfLight;
    public int maxStackBulletOfLight = 1;
    public bool isBootsOfSpeedFire;
    public float bootOfSpeedFireDamage;
    float bootsOfSpeedFireCDSpawn = 1f;

    private void Awake() 
    {
        instance = this;
    }
    private void Start()
    {
        minRange = PlayerStats.instance.minRange;
        maxRange = PlayerStats.instance.maxRange;
        anim = GetComponent<Animator>();
        //get attack information
        attackSpeed = PlayerStats.instance.attackSpeed * PlayerStats.instance.attackSpeedMutilple;
        attackSpeedCD = attackSpeed;
    }
    private void Update()
    {
        //test item area
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject swordOfLight = Instantiate(itemFX_Sword_Of_Light, transform.position, transform.rotation);
            swordOfLight.GetComponent<ItemEffectSwordOfLight>().damage = 100f;
            Destroy(swordOfLight, 4f);
        }
        //test item area
        ItemCallForBootsOfSpeed();
        attackSpeed = PlayerStats.instance.attackSpeed * PlayerStats.instance.attackSpeedMutilple;

        closestEnemy = FindClosestTarget(minRange, maxRange);
        if (closestEnemy == null) return;

        // staff look at enemy
        Vector3 dir = closestEnemy.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        playerStaff.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        AutoFire();
    }

    private void AutoFire()
    {
        //check can attack
        attackSpeedCD -= Time.deltaTime;
        if (attackSpeedCD <= 0 && closestEnemy != null)
        {
            PlayerFire();
            attackSpeedCD = attackSpeed;
        }
    }

    public void PlayerFire()
    {
        if (!isBulletOfLight)
        {
            int randomBullet = Random.Range(0, bullets.Length);
            GameObject bullet = (GameObject)Instantiate(bullets[randomBullet], firePoint.transform.position, playerStaff.transform.rotation);
            bullet.GetComponent<PlayerBullet>().SetDamage(PlayerStats.instance.totalDmg);
        }
        else
        {
            GameObject bullet = (GameObject)Instantiate(bulletOfLight, firePoint.transform.position, playerStaff.transform.rotation);
            bullet.GetComponent<PlayerBullet>().SetDamage(PlayerStats.instance.totalDmg);
        }
        GameManager.instance.beforeHitTrigger = true;
    }

    private GameObject FindClosestTarget(float minRange, float maxRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            Vector3 calDistance = enemy.transform.position - transform.position;
            float curDistance = calDistance.sqrMagnitude;
            if (curDistance < distance*distance && curDistance >= minRange*minRange && curDistance <= maxRange*maxRange)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void SetAnimationMove()
    {
        anim.SetBool("isIdle", false);
    }
    public void SetAnimationIdle()
    {
        isIdle = true;
        if (closestEnemy != null) return;
        anim.SetBool("isIdle", true);
    }

    //for item call
    public void ItemCallForBootsOfSpeed()
    {
        bootsOfSpeedFireCDSpawn -= Time.deltaTime;
        if (isBootsOfSpeedFire && (bootsOfSpeedFireCDSpawn <= 0))
        {
            GameObject fireFootPrint = Instantiate(bootsOfSpeedFire, transform.position, transform.rotation) as GameObject;
            fireFootPrint.GetComponent<PlayerBullet>().damage = bootOfSpeedFireDamage;
            Destroy(fireFootPrint, 3f);
            bootsOfSpeedFireCDSpawn = 0.5f;
        }
    }
    public void ItemCallForSnipeGun()
    {
        StartCoroutine(SnipeGunFuction());
    }
    IEnumerator SnipeGunFuction()
    {
        yield return new WaitForSeconds(0.2f);
        int randomBullet = Random.Range(0, bullets.Length);
        GameObject bullet = (GameObject)Instantiate(bullets[randomBullet], firePoint.transform.position, playerStaff.transform.rotation);
        bullet.GetComponent<PlayerBullet>().SetDamage(PlayerStats.instance.totalDmg);
    }
    public void ItemCallForFireStaff(float dmgBonus, int multicastTime, bool isDestroyInstantiateFrag, float dmgFireCrack)
    {
        StartCoroutine(FireStaffFunction(isDestroyInstantiateFrag, dmgBonus, multicastTime, dmgFireCrack));
        //call dmgbonus in bullet
    }

    IEnumerator FireStaffFunction(bool isMiniFireBall, float dmgDeal, int castTime, float miniFireBallDmg)
    {
        while (castTime > 0)
        {
            GameObject bullet = (GameObject)Instantiate(fireStaffFireBall, firePoint.transform.position, playerStaff.transform.rotation);
            bullet.GetComponent<PlayerBullet>().SetDamage(dmgDeal);
            if (isMiniFireBall)
            {
                bullet.GetComponent<PlayerFireBall>().isMiniFireball = true;
                bullet.GetComponent<PlayerFireBall>().dmg = miniFireBallDmg;
                bullet.GetComponent<PlayerFireBall>().fireBallNumber = 3;
            }
            yield return new WaitForSeconds(0.2f);
            castTime--;
        }
    }

    public void ItemCallForWindWhisper(float dmgDeal, bool isKnockBack, float radius = 1f)
    {
        GameObject windArea = (GameObject)Instantiate(itemFX_windWhisper, transform.position, transform.rotation);
        windArea.transform.localScale *= radius; 
        windArea.GetComponent<ItemEffectWindWhirl>().dmg = dmgDeal;

        if (isKnockBack)
        {
            windArea.GetComponent<ItemEffectWindWhirl>().isKnockBack = isKnockBack;
        }
        Destroy(windArea, 5f);
    }

    public void ItemCallForBowOfDevil(float percentHPDmg, bool isKnockBack)
    {
        GameObject arrowOfDevil = (GameObject)Instantiate(itemFX_bowOfDevil, firePoint.transform.position, playerStaff.transform.rotation);
        arrowOfDevil.GetComponent<ItemEffectBowOfDevil>().percentHPdmg = percentHPDmg;
        if (isKnockBack)
        {
            arrowOfDevil.GetComponent<ItemEffectBowOfDevil>().isKnockBack = isKnockBack;
        }

        arrowOfDevil.GetComponent<ItemEffectBowOfDevil>().DealDamage();
    }
    public void ItemCallForMaskOfLife(float dmg)
    {
        GameObject areaDmg = (GameObject)Instantiate(itemFX_maskOfLife, transform.position, transform.rotation);
        areaDmg.GetComponent<ItemEffectMaskOfLife>().dmg = dmg;
    }
    public void ItemCallForIceBall(float buffDuration, float dmg)
    {
        GameObject iceBall = (GameObject)Instantiate(itemFX_iceBall, firePoint.transform.position, playerStaff.transform.rotation);
        iceBall.GetComponent<BuffAdder>().buffDur = buffDuration;
        iceBall.GetComponent<ItemEffectIceBall>().dmgZone.damage = dmg;

        Destroy(iceBall, 5f);
    }
    public void IemCallForIceBallAreaDmg(float buffDur, float fragDmg)
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject iceFrag = (GameObject)Instantiate(itemFX_iceBall_Fragment, transform.position, Quaternion.Euler(0f, 0f, 30f * i));
            iceFrag.GetComponent<BuffAdder>().buffDur = buffDur;
            iceFrag.GetComponent<ItemEffectIceBall>().dmgZone.damage = fragDmg;
        }
    }
    public void ItemCallForFallenSky(float dmgDeal, float radius, bool isLevel4, float lavarDmg, float lavarTime)
    {
        Vector2 randomPos = new Vector2(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1));
        GameObject fallenMeterior = (GameObject)Instantiate(itemFX_fallen_Sky, randomPos, transform.rotation);
        fallenMeterior.GetComponent<ItemEffectFallenSky>().radius = radius;
        fallenMeterior.GetComponent<ItemEffectFallenSky>().mainDmg = dmgDeal;
        fallenMeterior.GetComponent<ItemEffectFallenSky>().isLavar = isLevel4;
        fallenMeterior.GetComponent<ItemEffectFallenSky>().lavarDmg = lavarDmg;
        fallenMeterior.GetComponent<ItemEffectFallenSky>().lavarTime = lavarTime;
        Destroy(fallenMeterior, 10f);
    }

    public void ItemCallForBookOfKnowledge()
    {
        foreach (var slot in ItemSlots.instance.slotMinis)
        {
            if (slot.isItem && slot.itemID != 10)
            {
                slot.itemType.skillCDCD = 0.5f;
            }
        }
    }
    public void ItemCallForSwordOfLight(float percenDmg)
    {
        GameObject swordOfLight = Instantiate(itemFX_Sword_Of_Light, transform.position, transform.rotation);
        swordOfLight.GetComponent<ItemEffectSwordOfLight>().damage = (int)PlayerStats.instance.currentRunSoulGet * percenDmg;
        Destroy(swordOfLight, 4f);
    }
}
