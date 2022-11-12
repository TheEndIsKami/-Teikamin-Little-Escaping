using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    public float flySpeed = 4f;
    public float magnetRange = 5f;
    [SerializeField] int expAmount = 86;

    float initSpeed = 1f;
    Vector2 randomDir;
    Vector3 playerDir;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 randomRotate = new Vector3(0f, 0f, Random.Range(-360, 360));
        transform.rotation = Quaternion.Euler(randomRotate);

        rb = GetComponent<Rigidbody2D>();
        randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        randomDir.Normalize();
    }
    private void Update()
    {
        rb.velocity = randomDir * initSpeed;
        initSpeed = Mathf.MoveTowards(initSpeed, 0f, Time.deltaTime);

        if (PlayerStats.instance == null) return;
        playerDir = PlayerController.instance.transform.position - transform.position;
        if (magnetRange * magnetRange >= playerDir.sqrMagnitude)
        {
            //flying toward player
            playerDir.Normalize();
            rb.velocity = playerDir * flySpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.totalExp += expAmount;
            UIManager.instance.UpdateUI();
            GameManager.instance.UpdatePlayerLevel();
            Destroy(gameObject);
        }
    }
    public void SetExpDropAmount(int amount)
    {
        expAmount = amount;
    }
}
