using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSnipeGun : Item
{
    public override void Function()
    {
        if (!isEquip) return;
        //for passive
        if (!isPassive)
        {
            //do nothing
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
            int randomChance = Random.Range(0, 100);
            float chancePerLevel = 0;

            if (level >= 1)
            {
                chancePerLevel = 7f;
                if (level >= 2)
                {
                    chancePerLevel = 10f;
                    if (level >= 4)
                    {
                        chancePerLevel = 17f;
                        if (level >= 6)
                        {
                            chancePerLevel = 22f;
                            if (level >= 9)
                            {
                                chancePerLevel = 27f;
                                if (level >= 10)
                                {
                                    chancePerLevel = 32f;
                                }
                            }
                        }
                    }
                }
            }
            if (randomChance <= chancePerLevel)
            {
                PlayerController.instance.ItemCallForSnipeGun();
                if (level >= 5) skillCDCD -= 1f;
            }
            isBeforeHit = false;
            GameManager.instance.beforeHitTrigger = false;
        }
    }
    public override void Unequip()
    {
        //do nothing
    }
    public override void CheckActive() //thay lai level >= 3
    {
        if (level >= 3 && skillCDCD <= 0)
        {
            //set condition
            skillCD = 10f;
            if (level >= 3)
            {
                skillDur = 5f;
                if (level >= 7)
                {
                    skillDur = 7f;
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
            tempPrams = 0.75f;
            if (level >= 8)
            {
                tempPrams = 0.55f;
            }
            PlayerStats.instance.attackSpeedMutilple = tempPrams;
            return;
        }
        PlayerStats.instance.attackSpeedMutilple = 1f;

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
