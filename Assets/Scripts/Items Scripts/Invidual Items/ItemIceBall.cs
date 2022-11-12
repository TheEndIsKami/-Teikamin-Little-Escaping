using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIceBall : Item
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
            tempPrams++;
            if (tempPrams >= 5 || (tempPrams >= 4 && level >= 4) || (tempPrams >= 3 && level >= 6))
            {
                float dmg = PlayerStats.instance.totalDmg * 0.5f;
                if (level >= 3) dmg = PlayerStats.instance.totalDmg * 1f;
                if (level >= 7) dmg = PlayerStats.instance.totalDmg * 1.5f;
                if (level >= 9) dmg = PlayerStats.instance.totalDmg * 2.5f;

                PlayerController.instance.ItemCallForIceBall(2f, dmg);
                tempPrams = 0;
            }
            
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
        if (level >= 2 && skillCDCD <= 0)
        {
            skillCD = 20f;
            skillDur = 2f;

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
        float dmg = PlayerStats.instance.totalDmg * 0.5f;
        if (level >= 5) dmg += dmg;
        if (level >= 8) dmg += PlayerStats.instance.totalDmg * 0.5f;
        if (level >= 10) dmg += PlayerStats.instance.totalDmg * 1f;

        PlayerController.instance.IemCallForIceBallAreaDmg(skillDur, dmg);

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
