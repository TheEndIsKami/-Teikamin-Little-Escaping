using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHPBar : MonoBehaviour
{
    public static BossHPBar instance;
    public Slider slider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slider.value = 0f;
        slider.gameObject.SetActive(false);
    }
    public void UpdateHPBar(float currentHP, float maxHP)
    {
        slider.gameObject.SetActive(true);
        slider.maxValue = maxHP;
        slider.value = currentHP;
        if (currentHP <= 0)
        {
            slider.gameObject.SetActive(false);
        }
    }
}
