using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossKoboltBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject dmgPopup;
    [SerializeField] GameObject explodeFrag;

    float explodeTime = 2f;
    float damage;
    Rigidbody2D rb;
    Vector3 playerDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 playerPos = PlayerController.instance.transform.position;
        playerPos = new Vector3(playerPos.x + Random.Range((playerPos.x * 0.5f), playerPos.x * -0.5f),
            playerPos.y + Random.Range((playerPos.y * 0.5f), playerPos.y * -0.5f), playerPos.z);
        playerDir = playerPos - transform.position;
        playerDir.Normalize();

        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    private void Update()
    {
        rb.velocity = playerDir * speed;
        explodeTime -= Time.deltaTime;

        if (explodeTime <= 0)
        {
            for (int i = 0; i < 13; i++)
            {
                Vector3 rotate = new Vector3(0f, 0f, i * 30f);
                GameObject frag = Instantiate(explodeFrag, transform.position, Quaternion.Euler(rotate));
                frag.GetComponent<EnemyBossKoboltBulletFrag>().SetDamage(damage * 0.3f);

                if (i == 12)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().Hurt(damage);
            Destroy(gameObject);
        }
    }
}
