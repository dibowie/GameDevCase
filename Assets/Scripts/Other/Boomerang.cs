using System;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;

    public Vector3 rotationAmount = new Vector3(0, 360, 0); // Rotation amount in degrees
    public float duration = 5f;
    public static event Action OnEnemyDied;
    private void Start()
    {
        Rotate();
        LeanPool.Despawn(this,5);
    }

    private void Rotate()
    {
        transform.DORotate(rotationAmount, duration)
            .SetEase(Ease.OutQuad);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.CompareTag("Enemy"))
        {
            OnEnemyDied?.Invoke();
            LeanPool.Despawn(this);
        }
    }
}

