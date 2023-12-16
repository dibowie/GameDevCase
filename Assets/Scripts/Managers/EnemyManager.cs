using Lean.Pool;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies;
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
        
        float sphereRadius = Mathf.Max(spawnRangeX, spawnRangeY);
        
        Vector2 randomCircle = Random.insideUnitCircle * sphereRadius;
        
        float spawnY = Random.Range(camera.transform.position.y - halfHeight - spawnRangeY, camera.transform.position.y + halfHeight + spawnRangeY);

        
        Vector3 spawnPosition = new Vector3(randomCircle.x + camera.transform.position.x + halfWidth, 0, spawnY);
        return spawnPosition;
    }

    private void InstantiateEnemy(Vector3 spawnPosition)
    {
        var newEnemy = LeanPool.Spawn(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
        enemyController.SetTarget(target);
    }
}