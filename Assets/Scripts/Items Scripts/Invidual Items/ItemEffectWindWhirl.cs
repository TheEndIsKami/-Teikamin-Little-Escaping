using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectWindWhirl : MonoBehaviour
{
    [SerializeField] float rotateSpd;
    public float dmg; //must init when call
    public bool isKnockBack;
    public PlayerBullet dmgZone;
    private void Start()
    {
        dmgZone.gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, (rotateSpd * Time.deltaTime), Space.World);
    }

    public void DealDamageInAnim() //call in anim
    {
        dmgZone.gameObject.SetActive(true);
        if (isKnockBack) dmgZone.SetKnockBackCondition(isKnockBack);
        dmgZone.SetDamage(dmg);
    }
}
