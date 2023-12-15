using System;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    public static event Action OnDied;
    public static event Action OnCoinCollected;
    
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    private float _damageAmount = 1f;


    private void Start()
    {
        _currentHealth = maxHealth;
        healthBar.UpdateHealthbar(maxHealth, _currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyProjectile"))
        {
            other.gameObject.SetActive(false);
            TakeDamage();
        }
        if (other.transform.CompareTag("Enemy"))
        {
            Debug.Log("EnemyTouched");
            //player die
            OnDied?.Invoke();
        }
        if (other.transform.CompareTag("Coin"))
        {
            OnCoinCollected?.Invoke();
            other.gameObject.SetActive(false);
        }
    }

    private void TakeDamage()
    {
        _currentHealth -= _damageAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        healthBar.UpdateHealthbar(maxHealth, _currentHealth);
        if (_currentHealth <= 0)
        {
           // Die();
           Debug.Log("died");
           OnDied?.Invoke();
        }
    }
}
