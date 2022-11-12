using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAdder : MonoBehaviour
{
    public BuffManager.BuffCode thisBuff;
    public Buff buffType;
    public float buffDur;
    public int stack;

    private void Start()
    {
        buffType = BuffManager.instance.ReturnBuffType((int)thisBuff);
        buffType.buffDur = buffDur;
    }
}
