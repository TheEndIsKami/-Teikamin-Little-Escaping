using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;
    [SerializeField] GameObject[] bossLists;
    public float bossIncTime = 300f;
    int currentBoss;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        bossIncTime -= Time.deltaTime;
        if (bossIncTime <= 0)
        {
            Vector3 bossPos = PlayerStats.instance.transform.position + new Vector3(0f, 20f);
            Instantiate(bossLists[currentBoss], bossPos, Quaternion.identity);
            currentBoss++;
            bossIncTime = 300f;
        }
    }

}
