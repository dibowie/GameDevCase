using System;
using Lean.Pool;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{ 
    [SerializeField] private Transform attackIndicator;
    [SerializeField] private Transform boomerangPrefab;
    [SerializeField] private float attackRange = 12f;
    
    private TimeCounter _timeCounter;
    private float _shootTimer = 2f;
    

    private void Start()
    {
        _timeCounter = new TimeCounter(_shootTimer);
    }

    private void Update()
    {
        if (_timeCounter.IsTickFinished(Time.deltaTime))
        {
            HandleAttack();
        }
    }

    void HandleAttack()
    {
        attackIndicator.position = transform.position;
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                LaunchBoomerang(collider.transform.position);
                break;
            }
        }
    }
    void LaunchBoomerang(Vector3 targetPosition)
    {
       var boomerang = LeanPool.Spawn(boomerangPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity,transform.GetChild(0));
        Vector3 direction = (targetPosition - transform.position).normalized;
        boomerang.GetComponent<Rigidbody>().AddForce(direction * 20f, ForceMode.Impulse);
    }
}
