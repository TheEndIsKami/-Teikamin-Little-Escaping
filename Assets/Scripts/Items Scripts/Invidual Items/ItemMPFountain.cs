using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMPFountain : Item
{
    float mpRegen = 0f;
    public override void Function()
    {
        if (!isEquip) return;

        if (skillDurCD <= 0)
        {
            if (level >= 1)
            {
                mpRegen = 1f;
                if (level >= 2)
                {
                    mpRegen += 1f;
                    if (level >= 5)
                    {
                        mpRegen += 1f;
                    }
                }
            }
            PlayerStats.instance.mana += mpRegen;
            skillDurCD = 1f;
        }
        //for passive
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
        if (level >= 3 && skillCDCD <= 0 && PlayerStats.instance.hitPoint >= (10f - mpDecrease))
        {
            skillCD = 60f;
            PlayerStats.instance.hitPoint -= (10f - mpDecrease);

            //set skillDur and skillcd again
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
        if (level >= 3)
        {
            tempPrams = 0.3f;
        }
        if (level >= 4)
        {
            tempPrams = 0.5f;
        }
        PlayerStats.instance.mana += PlayerStats.instance.mana * tempPrams;
        //set condition again
        checkActive = false;
    }
}
