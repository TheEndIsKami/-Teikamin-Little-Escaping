using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public enum EnemyID { Slime, KoboltRanger, SlimeBoss}
    public GameObject[] enemyPrefabs;
    public GameObject enemyAppearFX;
    public float enemyAppearFXTime = 2f;

    [Header("Boss Wave Controller")]
    public GameObject[] bossList;
    public float bossTime;
    List<bool> currentBossWave = new List<bool>();
    public float currentBossTime;

    [Header("Normal Wave Controller")]
    [SerializeField] int currentWave;
    public float timeLeft;
    public int enemyInCurrentWave;
    public int enemyLeft;
    int totalEnemyInWaves;

    [Header("Enemy Wave List")]
    [SerializeField] EnemyWave[] wavesList;
    [SerializeField] EnemySpawner endlessEnemies;
    bool isActiveEndlessWave;
    bool isInfoWave;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentWave = -1;
        currentBossTime = bossTime;
        foreach (var boss in bossList)
        {
            currentBossWave.Add(false);
        }
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        currentBossTime -= Time.deltaTime;
        if (currentBossTime <= 0)
        {
            for (int i = 0; i < currentBossWave.Count; i++)
            {
                if (!currentBossWave[i])
                {
                    Instantiate(bossList[i], transform.position, Quaternion.identity);
                    currentBossWave[i] = true;
                    currentBossTime = bossTime;
                    return;
                }
            }
        }
        if (!isInfoWave)
        {
            NextWave();
        }
        enemyLeft = totalEnemyInWaves - PlayerStats.instance.totalEnemyKilled;

        if (timeLeft <= 0 || enemyLeft <= 0)
        {
            isInfoWave = false;
        }

        if ((currentWave + 1) >= wavesList.Length)
        {
            isActiveEndlessWave = true;
        }

        if (isActiveEndlessWave)
        {
            endlessEnemies.gameObject.SetActive(true);
        }
    }

    public void NextWave()
    {
        if ((currentWave + 1) >= wavesList.Length) return;
        currentWave += 1;
        Instantiate(wavesList[currentWave], transform.position, Quaternion.identity);
        timeLeft = wavesList[currentWave].clearTimeEstimate;
        enemyInCurrentWave = wavesList[currentWave].spawnPos.Count;
        totalEnemyInWaves += enemyInCurrentWave;
        isInfoWave = true;
    }
}
