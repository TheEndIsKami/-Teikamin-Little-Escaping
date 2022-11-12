using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaskOfLife : Item
{
    public override void Function()
    {
        if (!isEquip) return;

        //for passive
        if (!isPassive) //isPassive once time
        {
            isPassive = true;
        }
        //for on hit effect
        if (isOnHit)
        {
            float heal = 0f;
            float dmgMaskOfLife = 10f;
            int chance = 1;
            if (level >= 9) chance = 2;
            if (level >= 10) dmgMaskOfLife = 15f;
            if (level >= 1)
            {
                heal = 0.5f;
                if (level >= 2)
                {
                    heal = 1f;
                    if (level >= 3)
                    {
                        if (PlayerStats.instance.maxHitPoint * 0.2f >= PlayerStats.instance.hitPoint)
                        {
                            heal = 1 + 0.05f * PlayerStats.instance.totalDmg;
                        }
                        if (level >= 4)
                        {
                            if (Random.Range(1, 4) <= chance) PlayerController.instance.ItemCallForMaskOfLife(dmgMaskOfLife);
                            if (level >= 6)
                            {
                                heal += 0.5f;
                                if (level >= 7)
                                {
                                    heal += 0.5f;
                                    if (level >= 8)
                                    {
                                        heal += 0.05f * PlayerStats.instance.totalDmg;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            PlayerStats.instance.hitPoint += heal;
            if (PlayerStats.instance.hitPoint >= PlayerStats.instance.maxHitPoint) PlayerStats.instance.hitPoint = PlayerStats.instance.maxHitPoint;
            PlayerStats.instance.UpdateHPBar();
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
            skillCD = 60f;
            skillDur = 3f;

            //set skillDur and skillcd again
            skillDurCD = skillDur;
            skillCDCD = skillCD;
            checkActive = true;

            tempPrams = PlayerStats.instance.totalEnemyKilled;
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
            return;
        }
        PlayerStats.instance.maxHitPoint += (PlayerStats.instance.totalEnemyKilled - (int)tempPrams);

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
