using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFallenSky : Item
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
            skillCD = 30f;
            if (level >= 10) skillCD = 10f;
            bool isLevel4 = false;
            float dmgBonusTemp = PlayerStats.instance.totalDmg * 4f;
            float radius = 1f;
            float lavarDmg = PlayerStats.instance.totalDmg * 0.5f;
            float lavarTime = 5f;
            if (level >= 2)
            {
                radius = 1.1f;
                if (level >= 3)
                {
                    dmgBonusTemp = PlayerStats.instance.totalDmg * 5f;
                    if (level >= 4)
                    {
                        isLevel4 = true;
                        if (level >= 5)
                        {
                            radius *= 1.1f;
                            if (level >= 6)
                            {
                                radius *= 1.1f;
                                if (level >= 7)
                                {
                                    lavarTime = 7f;
                                    if (level >= 8)
                                    {
                                        radius *= 1.1f;
                                        if (level >= 9)
                                        {
                                            lavarTime = 10f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            PlayerController.instance.ItemCallForFallenSky(dmgBonusTemp, radius, isLevel4, lavarDmg, lavarTime);
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
