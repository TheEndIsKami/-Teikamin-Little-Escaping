using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Text goldText;
    [SerializeField] GameObject deadMenu;
    [SerializeField] Slider expBar;
    [SerializeField] TextMeshProUGUI totalEnemyKilledText;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deadMenu.SetActive(false);
    }
    public void UpdateUI()
    {
        goldText.text = ((int)BossManager.instance.bossIncTime).ToString();
    }

    public void DeadScreen()
    {
        deadMenu.SetActive(true);
    }
    private void Update()
    {
        UpdateUI();
        UpdateExpBar();
        UpdateEnemyKilled();
    }

    public void UpdateExpBar()
    {
        expBar.maxValue = PlayerStats.instance.level * 20 + 100;
        expBar.minValue = 0;
        expBar.value = GameManager.instance.totalExp;
    }
    public void UpdateEnemyKilled()
    {
        totalEnemyKilledText.text = PlayerStats.instance.currentRunSoulGet.ToString();
    }
}
