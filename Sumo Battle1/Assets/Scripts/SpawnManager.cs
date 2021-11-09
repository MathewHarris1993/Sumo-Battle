using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //variables
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy
        SpawnEnemyWaves();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn multiple enemies
    void SpawnEnemyWaves()
    {
        for (int i = 0; i < 3; i++)
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
