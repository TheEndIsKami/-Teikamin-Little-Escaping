using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBookOfKnowledge : Item
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
            skillCD = 60f;
            if (level >= 2)
            {
                skillCD -= 5f;
                if (level >= 3)
                {
                    skillCD -= 5f;
                    if (level >= 4)
                    {
                        skillCD -= 5f;
                        if (level >= 5)
                        {
                            skillCD -= 5f;
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
            PlayerController.instance.ItemCallForBookOfKnowledge();
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
