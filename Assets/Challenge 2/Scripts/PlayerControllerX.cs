using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float lastSpawnTime;
    private float spawnInterval = 1.5f;
    void Start()
    {
        lastSpawnTime = Time.time - spawnInterval; // Устанавливаем начальное время спавна
    }

    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpawnTime >= spawnInterval)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawnTime = Time.time; // Обновляем время последнего спавна
        }
    }
}
