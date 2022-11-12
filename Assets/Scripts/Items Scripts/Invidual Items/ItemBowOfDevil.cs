using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBowOfDevil : Item
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
            skillCD = 40f;
            bool isKnockBack = false;
            float percentDPS = 0f;

            if (level >= 1)
            {
                percentDPS = 0.1f;
                if (level >= 2)
                {
                    skillCD = 35f;
                    if (level >= 3)
                    {
                        skillCD = 30f;
                        if (level >= 4)
                        {
                            isKnockBack = true;
                            if (level >= 5)
                            {
                                percentDPS = 0.15f;
                                if (level >= 6)
                                {
                                    skillCD -= 5f;
                                    if (level >= 7) 
                                    {
                                        skillCD -= 5f;
                                        if (level >= 8)
                                        {
                                            skillCD -= 5f;
                                            if (level >= 9)
                                            {
                                                skillCD -= 5f;
                                                if (level >= 10)
                                                {
                                                    skillCD -= 5f;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            PlayerController.instance.ItemCallForBowOfDevil(percentDPS, isKnockBack);
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
