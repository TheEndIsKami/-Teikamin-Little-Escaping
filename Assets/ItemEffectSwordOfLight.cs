using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectSwordOfLight : MonoBehaviour
{
    public float damage;
    [SerializeField] GameObject dmgZone;

    float prepareTime = 0.5f;
    float rotateSpd = 10f;
    private void Start()
    {
        dmgZone.gameObject.SetActive(false);
    }

    private void Update()
    {
        prepareTime -= Time.deltaTime;
        if (prepareTime > 0)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, (rotateSpd * Time.deltaTime), Space.World);
        }
        else
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, (Mathf.MoveTowards(-rotateSpd, -rotateSpd*100f, Time.deltaTime * 40)), Space.World);
        }
    }
    public void CallDmgZone()
    {
        dmgZone.gameObject.SetActive(true);
        dmgZone.GetComponent<PlayerBullet>().damage = damage;
    }
}
