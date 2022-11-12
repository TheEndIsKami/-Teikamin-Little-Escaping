using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : MonoBehaviour
{
    int goldAmount;
    private void Start()
    {
        Destroy(gameObject, 30f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.totalGold += goldAmount;
            UIManager.instance.UpdateUI();
            Destroy(gameObject);
        }
    }
    public void SetGoldDropAmount(int amount)
    {
        goldAmount = amount;
    }
}
