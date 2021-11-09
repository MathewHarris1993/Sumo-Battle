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
        //spawn location random
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosy = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosy);


        //spawn enemy
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
