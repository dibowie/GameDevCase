using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 shootPoint;
    
    
    private void Update()
    {

        if (shootPoint == null)
        {
            return;
        }
        transform.position += shootPoint * Time.fixedTime * .1F * moveSpeed;
    }
    private void Start()
    {
        LeanPool.Despawn(this,4);
    }
    
    public void InitBullet(float bulletDamage, Transform gunPoint,Transform sourceObject)
    {
        shootPoint = gunPoint.forward;
    }
}
