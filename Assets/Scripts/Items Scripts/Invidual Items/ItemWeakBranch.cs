using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeakBranch : Item
{
    bool isL1, isL2, isL3, isL5, isL6, isL8, isL10;
    public override void Function()
    {
        if (!isEquip) return;
        //for passive
        if (!isL1 && level >= 1)
        {
            PlayerStats.instance.normalAttackDamage += 2f;
            isL1 = true;
        }
        if (!isL2 && level >= 2)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isL2 = true;
        }
        if (!isL3 && level >= 3)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isL3 = true;
        }
        if (!isL5 && level >= 5)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isL5 = true;
        }
        if (!isL6 && level >= 6)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isL6 = true;
        }
        if (!isL8 && level >= 8)
        {
            PlayerStats.instance.normalAttackDamage += 5f;
            isL8 = true;
        }
        if (!isL10 && level >= 10)
        {
            PlayerStats.instance.normalAttackDamage += PlayerStats.instance.normalAttackDamage * 0.1f;
            isL10 = true;
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
        PlayerStats.instance.normalAttackDamage -= 2f;
    }
    public override void CheckActive()
    {
        if (level >= 4 && skillCDCD <= 0)
        {
            skillCD = 20f;
            if (level >= 4)
            {
                skillDur = 5f;
                if (level >= 9)
                {
                    skillDur = 10f;
                }
            }

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
            tempPrams = 1.2f;
            if (level >= 7)
            {
                tempPrams = 1.5f;
            }
            PlayerStats.instance.totalDmgMultiple = tempPrams;
            return;
        }
        PlayerStats.instance.totalDmgMultiple = 1f;

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
