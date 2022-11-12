using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public bool isEquip;
    public int itemID;
    public int level;
    public float skillCD;
    public float skillCDCD; //goi trong ham khac lien tuc tru theo thoi gian
    public float mpDecrease = 0;
    public float skillDur;
    public float skillDurCD; //goi trong ham khac lien tuc tru theo thoi gian
    public float tempPrams; //for another skills need this
    public bool checkActive;

    public bool isPassive;
    public bool isOnHit;
    public bool isBeforeHit;
    public abstract void Function();
    public abstract void CheckActive();
    public abstract void Active();
    public abstract void Unequip();
}
