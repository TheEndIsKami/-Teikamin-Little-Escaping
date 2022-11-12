using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectFallenSkyWarningCircle : MonoBehaviour
{
    public float timeWarn = 2f;
    public float size = 3f;
    Vector3 scale;
    private void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }
    private void Update()
    {
        scale = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(size, size, size), Time.deltaTime/4.2f);
        transform.localScale += scale;
        timeWarn -= Time.deltaTime;
        if (timeWarn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
