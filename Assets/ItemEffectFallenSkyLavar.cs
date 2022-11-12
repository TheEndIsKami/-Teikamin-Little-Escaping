using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectFallenSkyLavar : MonoBehaviour
{
    public float lavarDmg;
    public float dmgCircle = 0.7f;
    [SerializeField] GameObject dmgZone;

    private void Update()
    {
        dmgCircle -= Time.deltaTime;

        if (dmgCircle <= 0)
        {
            GameObject dmgZoneLavar = Instantiate(dmgZone, transform.position, transform.rotation) as GameObject;
            dmgZoneLavar.GetComponent<PlayerBullet>().damage = lavarDmg;
            Destroy(dmgZoneLavar, 0.5f);

            dmgCircle = 0.7f;
        }
    }
}
