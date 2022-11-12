using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    float moveUpSpeed = 0.7f;
    float beforeFade = 1f;
    float dmgPopup;
    TextMeshPro text;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        text.text = ((int)dmgPopup).ToString();

        //fade out
        beforeFade -= Time.deltaTime;
        if (beforeFade <= 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(text.color.a, 0f, 3 * Time.deltaTime));
        }
        //move up
        transform.position += moveUpSpeed * Vector3.up * Time.deltaTime;

        //auto sort
        text.sortingOrder = Mathf.RoundToInt(transform.position.y * -1000f);
    }
    public void GetDamageNumber(float amount)
    {
        dmgPopup = amount;
    }
}
