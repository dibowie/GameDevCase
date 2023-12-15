using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private float spawnRadius;
    public Transform target;

    private TimeCounter _timeCounter;
    private int _enemySpawnTimer = 5;
    void Start()
    {
        SpawnEnemies();
        _timeCounter = new TimeCounter(_enemySpawnTimer);
    }

    private void Update()
    {
        if (_timeCounter.IsTickFinished(Time.deltaTime))
        {
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomSpawnPosition = Random.insideUnitSphere * spawnRadius;
            randomSpawnPosition.y = 0; 

            GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
            newEnemy.transform.parent = transform;
            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
            enemyController.SetTarget(target);
        }
    }
}