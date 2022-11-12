using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;
    public enum BuffCode { Slow, Purify}
    public Sprite[] itemSprite;

    private void Awake()
    {
        instance = this;
    }

    public Buff ReturnBuffType(int buffID)
    {
        Buff buff = buffID switch
        {
            0 => new BuffSlow(),
            _ => new BuffSlow(),
        };
        return buff;
    }
}
