using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Manager")]
    public int totalGold = 0;
    public float totalExp = 0;
    public int totalEnemyKilled = 0;
    public int totalEnemyHasSpawned;
    public int currentEnemyLeft;
    public double gameTime; //to make enemystronger
    [Header("Item Cache")]
    public ItemSlotMini[] currentItem;

    public bool onHitTrigger;
    public bool beforeHitTrigger;

    private void Awake() { instance = this; }
    private void Start()
    {
        PlayerStats.instance.gameObject.SetActive(true);
        //get stats from saved
        PlayerStats.normalATK = PlayerPrefs.GetFloat("NormalATK");
        PlayerStats.normalMaxHP = PlayerPrefs.GetFloat("NormalMaxHP");
        PlayerStats.normalSpd = PlayerPrefs.GetFloat("NormalSPD");

        PlayerStats.soulGet = PlayerPrefs.GetInt("Soul");

        PlayerStats.instance.normalAttackDamage = PlayerStats.normalATK;
        MoveByTouch.instance.baseSpeed = PlayerStats.normalSpd;
        PlayerStats.instance.maxHitPoint = PlayerStats.normalMaxHP;
    }
    private void Update()
    {
        if (!PlayerStats.instance.gameObject.activeInHierarchy) return;

        currentEnemyLeft = totalEnemyHasSpawned - totalEnemyKilled;
        gameTime += Time.deltaTime;
        foreach (ItemSlotMini slot in currentItem)
        {
            if (!slot.isItem) break;
            slot.itemType.level = slot.itemLevel;
            if (beforeHitTrigger)
            {
                slot.itemType.isBeforeHit = true;
            }
            if (onHitTrigger)
            {
                slot.itemType.isOnHit = true;
            }
            slot.itemType.Function();
            slot.itemType.skillCDCD -= Time.deltaTime;
            slot.itemType.skillDurCD -= Time.deltaTime;
            slot.itemType.CheckActive();
        }
        beforeHitTrigger = false;
        onHitTrigger = false;
        totalEnemyKilled = PlayerStats.instance.totalEnemyKilled;
    }

    public void UpdatePlayerLevel()
    {
        if (totalExp >= (PlayerStats.instance.level * 20 + 100))
        {
            PlayerStats.instance.level++;
            totalExp -= (PlayerStats.instance.level * 20 + 100);
            PopupWhenLevelUp.instance.gameObject.SetActive(true);
            PopupWhenLevelUp.instance.ChooseItems();
        }
    }
    public float RandomDamage(float avgDamage)
    {
        //damage will random between 20%, min = 1
        float min = avgDamage * 0.8f;
        float max = avgDamage * 1.2f;
        avgDamage = Mathf.RoundToInt(Random.Range(min, max));
        return avgDamage;
    }
}
