using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindWhisper : Item
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
            bool isKnockBack = false;
            float dmgBonusTemp = 0f;
            float radius = 1f;
            if (level >= 1)
            {
                dmgBonusTemp = 0.5f * PlayerStats.instance.totalDmg;
                if (level >= 2)
                {
                    dmgBonusTemp = 0.75f * PlayerStats.instance.totalDmg;
                    if (level >= 3)
                    {
                        dmgBonusTemp = 1f * PlayerStats.instance.totalDmg;
                        if (level >= 4)
                        {
                            isKnockBack = true;
                            if (level >= 5)
                            {
                                dmgBonusTemp = 1.5f * PlayerStats.instance.totalDmg;
                                if (level >= 6)
                                {
                                    dmgBonusTemp = 2f * PlayerStats.instance.totalDmg;
                                    if (level >= 8)
                                    {
                                        dmgBonusTemp = 2.5f * PlayerStats.instance.totalDmg;
                                        if (level >= 9)
                                        {
                                            dmgBonusTemp = 3f * PlayerStats.instance.totalDmg;
                                            if (level >= 10)
                                            {
                                                dmgBonusTemp = 4f * PlayerStats.instance.totalDmg;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (level >= 7)
            {
                radius = 1.2f;
            }
            PlayerController.instance.ItemCallForWindWhisper(dmgBonusTemp, isKnockBack, radius);
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
