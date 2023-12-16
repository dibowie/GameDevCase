using Cinemachine;
using Lean.Pool;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies;
   // [SerializeField] private float spawnRadius;
    public Transform target;

    private int _enemySpawnTimer = 5;
    private TimeCounter _timeCounter;

    public float spawnRangeX = 40f;
    public float spawnRangeY = 40f;

    
    void Start()
    {
        _timeCounter = new TimeCounter(_enemySpawnTimer);
        SpawnEnemies();
    }

    void Update()
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
            Vector3 spawnPosition = CalculateSpawnPosition(Camera.main);
            InstantiateEnemy(spawnPosition);
        }
    }

    private Vector3 CalculateSpawnPosition(Camera camera)
    {
        float halfWidth = camera.aspect * camera.orthographicSize;
        float halfHeight = camera.orthographicSize;

        float spawnX = Random.Range(camera.transform.position.x + halfWidth, camera.transform.position.x + halfWidth + spawnRangeX);
        float spawnY = Random.Range(camera.transform.position.y - halfHeight - spawnRangeY, camera.transform.position.y + halfHeight + spawnRangeY);

        return new Vector3(spawnX, 0, spawnY);
    }

    private void InstantiateEnemy(Vector3 spawnPosition)
    {
       // GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
       var newEnemy = LeanPool.Spawn(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
        enemyController.SetTarget(target);
    }
}