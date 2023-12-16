using System;
using Lean.Pool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int coinCount;
    [SerializeField] private float sphereRadius;
    [SerializeField] private GameObject gameOverPanel;
    
    
    
    private void Start()
    {
        InstantiateCoins();
    }
    private void OnEnable()
    {
        PlayerTriggerController.OnDied += GameOver;
    }

    private void OnDisable()
    {
        PlayerTriggerController.OnDied -= GameOver;
    }

    private void InstantiateCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            
            float theta = Random.Range(0f, Mathf.PI * 2f);
            float phi = Random.Range(0f, Mathf.PI);

          
            float x = sphereRadius * Mathf.Sin(phi) * Mathf.Cos(theta);
            float z = sphereRadius * Mathf.Cos(phi);

            Vector3 randomPosition = new Vector3(x, 1, z);

            var pooledCoin= LeanPool.Spawn(coin, randomPosition, Quaternion.identity,gameObject.transform.GetChild(0));
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
