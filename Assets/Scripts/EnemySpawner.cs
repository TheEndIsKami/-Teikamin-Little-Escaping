using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesType;
    [SerializeField] GameObject enemyAppearFX;
    [SerializeField] float enemyAppearFXTime = 2f;
    [SerializeField] float spawnRangeX, spawnRangeY;
    [SerializeField] int startSpawnEnemies = 5;
    [SerializeField] int enemiesLeft = 6;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] int enemiesPerSpawn = 1;
    [SerializeField] float enemyPerWaveIncreament = 1;
    float timeBetweenSpawnCD;

    [Header("SpawnPosController")]
    [SerializeField] GameObject posSpawnParent;
    [SerializeField] GameObject posSpawnChildren;
    [SerializeField] int posQuantity = 157;
    [SerializeField] float angleIncrement = 0.04f;
    [SerializeField] float magnitudeDistance = 24f;
    List<GameObject> posSpawnList = new List<GameObject>();

    //test
    [SerializeField] GameObject bat;
    private void Start()
    {
        timeBetweenSpawnCD = timeBetweenSpawn;

        //create pos spawns
        for (int i = 0; i < posQuantity; i++)
        {
            float angle = i * angleIncrement;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitudeDistance;
            GameObject posx = Instantiate(posSpawnChildren, pos, Quaternion.identity);
            posx.transform.parent = posSpawnParent.transform;
            posSpawnList.Add(posx);
        }
    }
    private void Update()
    {
        if (PlayerStats.instance == null) return;

        enemyPerWaveIncreament += Time.deltaTime * 0.01f;
        if (enemyPerWaveIncreament >= enemiesPerSpawn) enemyPerWaveIncreament = enemiesPerSpawn;

        //if (enemiesLeft <= 0) return;
        //if (prepareTime >= 0) return;
        timeBetweenSpawnCD -= Time.deltaTime;
        if (timeBetweenSpawnCD > 0) return;
        if (GameManager.instance.currentEnemyLeft >= 20) return;
        for (int i = 1; i <= (int)enemyPerWaveIncreament; i++)
        {
            int randomPos = Random.Range(0, posQuantity);
            int randomEnemy = Random.Range(0, enemiesType.Length);

            Vector2 spawnPos = posSpawnList[randomPos].transform.position + PlayerStats.instance.transform.position;
            Instantiate(enemiesType[randomEnemy], spawnPos, Quaternion.identity);
        }
        timeBetweenSpawnCD = timeBetweenSpawn;

    }
}
