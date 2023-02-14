using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefab;
    private float spawnRangeX = 15;
    private float spawnPosZ = 10;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomObject()
    {
        int objectIndex = Random.Range(0, objectPrefab.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2, spawnPosZ);

            Instantiate(objectPrefab[objectIndex], spawnPos, objectPrefab[objectIndex].transform.rotation);
    }
}
