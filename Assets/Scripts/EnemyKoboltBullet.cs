using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKoboltBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject dmgPopup;

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

        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        rb.velocity = playerDir * speed;
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
