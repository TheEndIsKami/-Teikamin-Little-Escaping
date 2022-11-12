using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOldRibcage : Item
{
    bool isLv1 = false;
    bool isLv2 = false;
    bool isLv5 = false;
    bool isLv6, isLv7, isLv9;
    public override void Function()
    {
        if (!isEquip) return;

        //for passive
        if (level >= 1 && !isLv1)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv1 = true;
        }
        if (level >= 2 && !isLv2)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv2 = true;
        }
        if (level >= 5 && !isLv5)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv5 = true;
        }
        if (level >= 6 && !isLv6)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv6 = true;
        }
        if (level >= 7 && !isLv7)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv7 = true;
        }
        if (level >= 9 && !isLv9)
        {
            PlayerStats.instance.maxHitPoint *= 1.1f;
            PlayerStats.instance.hitPoint *= 1.1f;
            isLv9 = true;
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
        if (level >= 3 && skillCDCD <= 0)
        {
            skillCD = 60f;
            if (level >= 8) skillCD = 40f;
            if (level >= 10) skillCD = 30f;

            skillDur = 2f;

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
        if (level >= 3)
        {
            tempPrams = 0.2f;
        }
        if (level >= 4)
        {
            tempPrams = 0.3f;
        }
        if (PlayerStats.instance.hitPoint <= PlayerStats.instance.maxHitPoint * tempPrams)
        {
            PlayerStats.instance.hitPoint += PlayerStats.instance.maxHitPoint * 0.1f;
        }
        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
