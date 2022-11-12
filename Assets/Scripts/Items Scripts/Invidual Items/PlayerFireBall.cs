using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBall : MonoBehaviour
{
    [SerializeField] GameObject miniFireBall;
    public bool isMiniFireball;
    public int fireBallNumber;
    public float dmg;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isMiniFireball)
        {
            for (int i = 0; i < fireBallNumber; i++)
            {
                Vector2 randomDir = new Vector2(Random.Range(-360f, 360f), Random.Range(-360f, 360f));
                GameObject miniFire = Instantiate(miniFireBall, transform.position, Quaternion.Euler(randomDir)) as GameObject;
                miniFire.GetComponent<PlayerBullet>().SetDamage(dmg);
            }
        }
    }
}
