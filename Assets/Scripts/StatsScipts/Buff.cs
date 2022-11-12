using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    public bool isbuff;
    public int buffID;
    public int level;
    public float buffCD;
    public float buffCDCD; //goi trong ham khac lien tuc tru theo thoi gian
    public float buffDur;
    public float buffDurCD; //goi trong ham khac lien tuc tru theo thoi gian
    public float tempPrams; //for another skills need this

    public abstract void Function();
}
