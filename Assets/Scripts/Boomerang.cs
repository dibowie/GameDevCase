using System;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;

    public static event Action OnEnemyDied;
    private void Start()
    {
        Rotate();
        LeanPool.Despawn(this,5);
    }

    private void Rotate()
    {
        transform.Rotate(rotationSpeed,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            OnEnemyDied?.Invoke();
        }
    }
}

