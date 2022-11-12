using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBootsOfSpeed : Item
{
    public override void Function()
    {
        if (!isEquip) return;

        //for passive
        if (level >= 1)
        {
            MoveByTouch.instance.speedBoots = 1.1f;
            if (level >= 3)
            {
                MoveByTouch.instance.speedBoots = 1.2f;
                if (level >= 4)
                {
                    MoveByTouch.instance.speedBoots = 1.3f;
                    if (level >= 6)
                    {
                        MoveByTouch.instance.speedBoots = 1.4f;
                        if (level >= 7)
                        {
                            PlayerController.instance.isBootsOfSpeedFire = true;
                            PlayerController.instance.bootOfSpeedFireDamage = PlayerStats.instance.totalDmg * 0.2f;
                            if (level >= 10)
                            {
                                PlayerController.instance.bootOfSpeedFireDamage = PlayerStats.instance.totalDmg * 0.5f;
                            }
                        }
                    }
                }
            }
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
        if (level >= 2 && skillCDCD <= 0)
        {
            skillCD = 30f;
            if (level >= 2)
            {
                skillDur = 2f;
                if (level >= 5)
                {
                    skillDur = 3f;
                    if (level >= 9)
                    {
                        skillDur = 5f;
                    }
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
            tempPrams = 1.25f;
            if (level >= 8)
            {
                tempPrams = 1.40f;
            }
            MoveByTouch.instance.speedMutilple = tempPrams;
            return;
        }
        MoveByTouch.instance.speedMutilple = 1f;

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
