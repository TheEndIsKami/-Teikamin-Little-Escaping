using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectMaskOfLife : MonoBehaviour
{
    [SerializeField] PlayerBullet damageZone;
    public float dmg;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void DealDamage()
    {
        damageZone.gameObject.SetActive(true);
        damageZone.damage = dmg;
    }
}
