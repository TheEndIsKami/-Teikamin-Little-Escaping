using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDemo : Item
{
    public override void Function()
    {
        if (!isEquip) return;
        //for passive
        if (level >= 1)
        {
            if (level >= 2)
            {
                if (level >= 3)
                {
                    if (level >= 4)
                    {
                        if (level >= 5)
                        {

                        }
                    }
                }
            }
        }
        if (!isPassive)
        {
            //do nothing
            isPassive = true;
        }
        //for on hit effect
        if (isOnHit)
        {
            if (level >= 1)
            {
                if (level >= 2)
                {
                    if (level >= 3)
                    {
                        if (level >= 4)
                        {
                            if (level >= 5)
                            {

                            }
                        }
                    }
                }
            }
            //do nothing
            isOnHit = false;
        }

        //for before hit effect
        if (isBeforeHit)
        {
            if (level >= 1)
            {
                if (level >= 2)
                {
                    if (level >= 3)
                    {
                        if (level >= 4)
                        {
                            if (level >= 5)
                            {

                            }
                        }
                    }
                }
            }
            //do nothing
            isBeforeHit = false;
        }
    }
    public override void Unequip()
    {

        //do nothing
        if (level >= 1)
        {
            if (level >= 2)
            {
                if (level >= 3)
                {
                    if (level >= 4)
                    {
                        if (level >= 5)
                        {

                        }
                    }
                }
            }
        }
    }
    public override void CheckActive()
    {
        if (level >= 4 && skillCDCD <= 0 && PlayerStats.instance.mana >= (30f - mpDecrease))
        {
            checkActive = true;
        }

        if (checkActive)
        {
            Active();
        }
    }
    public override void Active()
    {
        if (level >= 4 && skillCDCD <= 0 && PlayerStats.instance.mana >= (30f - mpDecrease))
        {
            PlayerStats.instance.mana -= (30f - mpDecrease);
            if (skillDur >= 0)
            {
                PlayerStats.instance.totalDmgMultiple = 1.2f;
                return;
            }
            skillCDCD = skillCD;
        }
    }
}
