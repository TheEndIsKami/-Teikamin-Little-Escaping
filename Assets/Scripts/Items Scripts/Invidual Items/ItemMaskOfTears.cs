using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaskOfTears : Item
{
    bool isLevel1;
    bool isLevel2;
    bool isLevel3;
    bool isLevel4;
    bool isActive;
    bool isLevel6, isLevel8;
    public override void Function()
    {
        if (!isEquip) return;
        tempPrams -= Time.deltaTime;
        if (tempPrams <= 0)
        {
            float dmgGet = 5f;
            if (level >= 6) dmgGet = 7f;
            if (level >= 8) dmgGet = 9f;
            if (!(PlayerStats.instance.hitPoint < (dmgGet + 1))) PlayerStats.instance.Hurt(dmgGet);
            tempPrams = 1f;
        }
        if (!isLevel1)
        {
            PlayerStats.instance.normalAttackDamage += 2f;
            isLevel1 = true;
        }
        if (!isLevel2)
        {
            PlayerStats.instance.attackSpeed -= (PlayerStats.instance.attackSpeed * 0.1f);
            isLevel2 = true;
        }
        if (!isLevel3)
        {
            PlayerStats.instance.normalAttackDamage += 2f;
            PlayerStats.instance.attackSpeed -= (PlayerStats.instance.attackSpeed * 0.05f);
            isLevel3 = true;
        }
        if (!isLevel4)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isLevel4 = true;
        }
        if (!isLevel6)
        {
            PlayerStats.instance.normalAttackDamage += 2f;
            isLevel6 = true;
        }
        if (!isLevel8)
        {
            PlayerStats.instance.attackSpeed -= 0.1f * PlayerStats.instance.attackSpeed;
            isLevel8 = true;
        }
        if (!isPassive) //isPassive once time
        {
            isPassive = true;
        }
        //for on hit effect
        if (isOnHit)
        {
            //do nothing
            isOnHit = false;
        }

        //for before hit effect
        if (isBeforeHit)
        {
            //do nothing
            isBeforeHit = false;
        }
    }
    public override void Unequip()
    {
        MoveByTouch.instance.speedBoots = 1f;
    }
    public override void CheckActive()
    {
        if (level >= 5 && skillCDCD <= 0)
        {
            skillCD = 20f;
            skillDur = 5f;
            if (level >= 7) skillDur = 7f;
            if (level >= 9) skillCD = 15f;
            if (level >= 10) skillCD = 10f;

            //set skillDur and skillcd again
            skillDurCD = skillDur;
            skillCDCD = skillCD;
            checkActive = true;
        }

        if (checkActive)
        {
            Active();
        }
    }
    public override void Active()
    {
        if (skillDurCD >= 0)
        {
            if (!isActive)
            {
                PlayerStats.instance.totalDmgMultiple += 0.1f;
                PlayerStats.instance.attackSpeedMutilple -= (PlayerStats.instance.attackSpeedMutilple * 0.1f);
                isActive = true;
            }
            return;
        }
        PlayerStats.instance.totalDmgMultiple = 1f;
        PlayerStats.instance.attackSpeedMutilple = 1f;
        //set condition again
        isActive = false;
        skillDurCD = skillDur;
        checkActive = false;
    }
}