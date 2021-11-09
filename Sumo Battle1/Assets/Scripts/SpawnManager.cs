using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //variables
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;
    public int powerUpCount;
    public int powerUpNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy
        SpawnEnemyWaves(waveNumber);
        SpawnPowerUp(powerUpNumber);

    }

    // Update is called once per frame
    void Update()
    {
        powerUpCount = FindObjectsOfType<PowerUp>().Length;
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
            powerUpNumber++;
            SpawnPowerUp(powerUpNumber);
        }
    }
    void SpawnPowerUp(int powerUpSpawn)
    {
        for(int i = 0; i < powerUpSpawn; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawn(), powerUpPrefab.transform.rotation);
        }
    }

    //spawn multiple enemies
    void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawn(), enemyPrefab.transform.rotation);
        }
    }

    //return spawn location
    private Vector3 GenerateSpawn()
    {
        //spawn location random
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosy = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosy);

        return randomPos;

    }
}
