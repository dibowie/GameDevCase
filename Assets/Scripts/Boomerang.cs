using System;
using DG.Tweening;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 720f; 
    [SerializeField] private float rotationDuration = 1f; 

    public static event Action OnEnemyDied;
    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0f, 0f, rotationSpeed), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            OnEnemyDied?.Invoke();
        }
    }
}

