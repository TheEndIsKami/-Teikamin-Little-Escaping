using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFireStaff : Item
{
    public override void Function()
    {
        return;
    }
    public override void Unequip()
    {
        return;
    }

    public override void CheckActive()
    {
        if (level >= 1 && skillCDCD <= 0)
        {
            skillCD = 5f;
            if (level >= 10)
            {
                skillCD = 3f;
            }
            int castTimes = 1;
            bool isLevel5 = false;
            float dmgBonusTemp = 0f;
            float dmgFireCrack = 0f;
            if (level >= 3)
            {
                castTimes = 2;
                if (level >= 6)
                {
                    castTimes = 3;
                    if (level >= 9)
                    {
                        castTimes = 4;
                    }
                }
            }
            if (level >= 1)
            {
                dmgBonusTemp = 1 * PlayerStats.instance.totalDmg;
                if (level >= 2)
                {
                    dmgBonusTemp = 1.5f * PlayerStats.instance.totalDmg;
                    if (level >= 4)
                    {
                        dmgBonusTemp = 2f * PlayerStats.instance.totalDmg;
                        if (level >= 5)
                        {
                            isLevel5 = true;
                            dmgFireCrack = 0.2f * PlayerStats.instance.totalDmg;
                            if (level >= 7)
                            {
                                dmgBonusTemp = 2.5f * PlayerStats.instance.totalDmg;
                                if (level >= 8)
                                {
                                    dmgFireCrack = 0.5f * PlayerStats.instance.totalDmg;
                                }
                            }
                        }
                    }
                }
            }

            PlayerController.instance.ItemCallForFireStaff(dmgBonusTemp, castTimes, isLevel5, dmgFireCrack);
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
        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
