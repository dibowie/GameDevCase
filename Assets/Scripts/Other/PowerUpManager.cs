using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPrefab;
    
    private int numberOfObjects = 1;
    private float spawnRadius = 20f;
    private TimeCounter _timeCounter;
    private int _powerUpSpawnTimer = 15;
    void Start()
    {
        SpawnObjects();
        _timeCounter = new TimeCounter(_powerUpSpawnTimer);
    }

    void Update()
    {
        if (_timeCounter.IsTickFinished(Time.deltaTime))
        {
            SpawnObjects();
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(powerUpPrefab, randomPosition, Quaternion.identity,transform);
        }
    }
    private Vector3 GetRandomPosition()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomX = spawnRadius * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float randomZ = spawnRadius * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);
        return randomPosition;
    }
}
