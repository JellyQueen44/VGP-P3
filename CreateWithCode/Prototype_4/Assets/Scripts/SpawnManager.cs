using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] bossPrefab;
    public GameObject powerupPrefab;
    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

            SpawnBossWave(1);
        }

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);

            
        }
    }

    void SpawnBossWave(int bossToSpawn)
    {
        int bossIndex = Random.Range(0, bossPrefab.Length);

        for (int i = 0; i < bossToSpawn; i++)
        {
            if(waveNumber % 3 == 0)
            {
                Instantiate(bossPrefab[bossIndex], GenerateSpawnPosition(), bossPrefab[bossIndex].transform.rotation);
            }
        }
    }
    

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
