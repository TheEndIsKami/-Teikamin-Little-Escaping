using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoulsManager : MonoBehaviour
{
    public static SoulsManager instance;

    [SerializeField] TextMeshProUGUI upATKText, upHPText, upSpdText;
    [SerializeField] TextMeshProUGUI buttonTextATK, buttonTextHP, buttonTextSpd;
    [SerializeField] TextMeshProUGUI currentSouls;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PlayerPrefs.SetFloat("NormalATK", PlayerStats.normalATK);
        PlayerPrefs.SetFloat("NormalMaxHP", PlayerStats.normalMaxHP);
        PlayerPrefs.SetFloat("NormalSPD", PlayerStats.normalSpd);
        PlayerPrefs.SetInt("LevelNormalATK", PlayerStats.levelNormalATK);
        PlayerPrefs.SetInt("LevelNormalMaxHP", PlayerStats.levelNormalMaxHP);
        PlayerPrefs.SetInt("LevelNormalSPD", PlayerStats.levelNormalSpd);
    }
    private void Update()
    {
        upATKText.text = PlayerPrefs.GetFloat("NormalATK").ToString("F1");
        upHPText.text = PlayerPrefs.GetFloat("NormalMaxHP").ToString("F1");
        upSpdText.text = PlayerPrefs.GetFloat("NormalSPD").ToString("F1");

        //in button
        buttonTextATK.text = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalATK")).ToString();
        buttonTextHP.text = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalMaxHP")).ToString();
        buttonTextSpd.text = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalSPD")).ToString();


        currentSouls.text = PlayerPrefs.GetInt("Soul").ToString();

    }

    public void UpgradeATKButton()
    {
        int cost = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalATK"));
        if (PlayerPrefs.GetInt("Soul") >= cost)
        {
            SpendSouls(cost);
            PlayerStats.normalATK = PlayerPrefs.GetFloat("NormalATK");
            PlayerStats.normalATK += 1f;
            PlayerPrefs.SetFloat("NormalATK", PlayerStats.normalATK);

            PlayerStats.levelNormalATK = PlayerPrefs.GetInt("LevelNormalATK");
            PlayerStats.levelNormalATK++;
            PlayerPrefs.SetInt("LevelNormalATK", PlayerStats.levelNormalATK);

            PlayerPrefs.Save();
        }
    }
    public void UpgradeHPButton()
    {
        int cost = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalATK"));
        if (PlayerPrefs.GetInt("Soul") >= cost)
        {
            SpendSouls(cost);
            PlayerStats.normalMaxHP = PlayerPrefs.GetFloat("NormalMaxHP");
            PlayerStats.normalMaxHP += 10f;
            PlayerPrefs.SetFloat("NormalMaxHP", PlayerStats.normalMaxHP);

            PlayerStats.levelNormalMaxHP = PlayerPrefs.GetInt("LevelNormalMaxHP");
            PlayerStats.levelNormalMaxHP++;
            PlayerPrefs.SetInt("LevelNormalMaxHP", PlayerStats.levelNormalMaxHP);

            PlayerPrefs.Save();
        }
    }
    public void UpgradeSPDButton()
    {
        int cost = ReturnAmountUpgrade(PlayerPrefs.GetInt("LevelNormalATK"));
        if (PlayerPrefs.GetInt("Soul") >= cost)
        {
            SpendSouls(cost);
            PlayerStats.normalSpd = PlayerPrefs.GetFloat("NormalSPD");
            PlayerStats.normalSpd += 0.1f;
            PlayerPrefs.SetFloat("NormalSPD", PlayerStats.normalSpd);

            PlayerStats.levelNormalSpd = PlayerPrefs.GetInt("LevelNormalSPD");
            PlayerStats.levelNormalSpd++;
            PlayerPrefs.SetInt("LevelNormalSPD", PlayerStats.levelNormalSpd);

            PlayerPrefs.Save();
        }
    }

    void SpendSouls(int amount)
    {
        if (PlayerPrefs.GetInt("Soul") >= amount)
        {
            PlayerStats.soulGet = PlayerPrefs.GetInt("Soul");
            PlayerStats.soulGet -= amount;
            PlayerPrefs.SetInt("Soul", PlayerStats.soulGet);
        }
    }

    int ReturnAmountUpgrade(int level)
    {
        int soulsCost = 1;
        switch (level)
        {
            case 1: soulsCost = 10; break;
            case 2: soulsCost = 50; break;
            case 3: soulsCost = 100; break;
            case 4: soulsCost = 200; break;
            case 5: soulsCost = 500; break;
            case 6: soulsCost = 800; break;
            case 7: soulsCost = 1100; break;
            case 8: soulsCost = 1500; break;
            default: soulsCost = 2000; break;
        }

        return soulsCost;
    }
}
