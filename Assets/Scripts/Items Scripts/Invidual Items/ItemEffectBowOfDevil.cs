using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectBowOfDevil : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] PlayerBullet damageZone;
    public float percentHPdmg;
    public bool isKnockBack = false;
    Rigidbody2D rb;

    private void Start()
    {
        damageZone.transform.parent = PlayerController.instance.playerStaff.transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    public void DealDamage()
    {
        StartCoroutine(StartDamageAfterDelay());
    }
    IEnumerator StartDamageAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        damageZone.gameObject.SetActive(true);
        if (isKnockBack)
        {
            damageZone.SetKnockBackCondition(true);
        }
        damageZone.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, PlayerController.instance.playerStaff.transform.rotation.z), Space.World);
        damageZone.percentHPdmg = percentHPdmg;
    }
}
