using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] private GameObject[] ballsPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 3.0f;
    private float maxSpawnInterval = 5.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnRandomBall()                                       
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballsPrefabs.Length);
        Instantiate(ballsPrefabs[ballIndex], spawnPos, ballsPrefabs[ballIndex].transform.rotation);
        UpdateSpawnInterval();
    }

    void UpdateSpawnInterval()
    {      
       float newInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
       CancelInvoke("SpawnRandomBall");
       InvokeRepeating("SpawnRandomBall", newInterval, newInterval);
    }
 

}                     
