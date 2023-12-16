using System;
using Lean.Pool;
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
            LeanPool.Despawn(other.gameObject);
            TakeDamage();
        }
        IKillable iKillable = other.GetComponent<IKillable>();
        if (iKillable != null)
        {
            Debug.Log("EnemyTouched");
            //player die
            OnDied?.Invoke();
        }

        ICollectable iCollectable = other.GetComponent<ICollectable>();
        if (iCollectable != null)
        {
            OnCoinCollected?.Invoke();
            LeanPool.Despawn(other.gameObject);
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
