using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] WaveManager.EnemyID enemyType;
    public List<Transform> spawnPos = new List<Transform>();
    public float clearTimeEstimate = 10f;

    private void Start()
    {
        foreach (Transform pos in spawnPos)
        {
            Vector3 spawnPos = pos.position + PlayerStats.instance.transform.position;
            StartCoroutine(SpawnEnemyAfterFX(spawnPos));
        }
    }
    IEnumerator SpawnEnemyAfterFX(Vector3 position)
    {
        //spawn
        GameObject enemyAppear = Instantiate(WaveManager.instance.enemyAppearFX, position, Quaternion.identity);
        Destroy(enemyAppear, 5f);
        yield return new WaitForSeconds(WaveManager.instance.enemyAppearFXTime);
        Instantiate(WaveManager.instance.enemyPrefabs[(int)enemyType], position, Quaternion.identity);
    }
}
