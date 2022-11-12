using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwordOfLight : Item
{
    bool isLevel1, isLevel2, isLevel4, isLevel5, isLevel6, isLevel8, isLevel9;
    public override void Function()
    {
        if (!isEquip) return;

        if (!isLevel1 && level >= 1)
        {
            PlayerController.instance.maxStackBulletOfLight = 1;
            isLevel1 = true;
        }
        if (!isLevel2 && level >= 2)
        {
            PlayerController.instance.maxStackBulletOfLight = 2;
            isLevel2 = true;
        }
        if (!isLevel4 && level >= 4)
        {
            PlayerController.instance.maxStackBulletOfLight = 3;
            isLevel4 = true;
        }
        if (!isLevel5 && level >= 5)
        {
            PlayerController.instance.maxStackBulletOfLight = 5;
            isLevel5 = true;
        }
        if (!isLevel6 && level >= 6)
        {
            PlayerController.instance.maxStackBulletOfLight = 7;
            isLevel6 = true;
        }
        if (!isLevel8 && level >= 8)
        {
            PlayerController.instance.maxStackBulletOfLight = 9;
            isLevel8 = true;
        }
        if (!isLevel9 && level >= 9)
        {
            PlayerController.instance.maxStackBulletOfLight = 11;
            isLevel9 = true;
        }
        //for passive
        if (!isPassive) //isPassive once time
        {
            PlayerController.instance.isBulletOfLight = true;
            isPassive = true;
        }
        //for on hit effect
        if (isOnHit)
        {
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
        PlayerController.instance.isBulletOfLight = false;
    }
    public override void CheckActive()
    {
        if (level >= 3 && skillCDCD <= 0)
        {
            skillCD = 60f;
            skillDur = 5f;

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
        tempPrams = 0.05f;
        if (level >= 7) tempPrams = 0.1f;
        if (level >= 10) tempPrams = 0.15f;
        PlayerController.instance.ItemCallForSwordOfLight(tempPrams);

        //set condition again
        skillDurCD = skillDur;
        checkActive = false;
    }
}
