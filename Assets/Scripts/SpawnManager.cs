using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] AnimalPrefabs;   //massive for animals prefabs   
    [SerializeField] private float sideSpawnMinZ;
    [SerializeField] private float sideSpawnMaxZ;
    [SerializeField] private float sideSpawnX;
    private float spawnRangeX = 18;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);   //calls the method after 2 seconds and repeats the call every 1.5 seconds
    }

    private void SpawnRandomAnimal()
    {
        SpawnLeftAnimal();
        SpawnRightAnimal();


        int AnimalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(AnimalPrefabs[AnimalIndex], spawnPos, AnimalPrefabs[AnimalIndex].transform.rotation); //create example
    }


    //left and right animals

    private void SpawnLeftAnimal()
    {
        int AnimalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(AnimalPrefabs[AnimalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    private void SpawnRightAnimal()

    {
        int AnimalIndex = Random.Range(0, AnimalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(AnimalPrefabs[AnimalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
