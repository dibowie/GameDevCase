using System;
using Cinemachine;
using Lean.Pool;
using UnityEngine;

public class EnemyController : MonoBehaviour, IKillable
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float stopDistance = 10.0f;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPoint;
    
    [SerializeField] private Animator enemyAnimator;


    private TimeCounter _timeCounter;
    private CinemachineImpulseSource _impulseSource;
    private void Awake()
    {
       enemyAnimator = GetComponent<Animator>();
       _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private Transform player;
    

    private void Start()
    {
        _timeCounter = new TimeCounter(enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void OnEnable()
    {
        Boomerang.OnEnemyDied += Die;
    }
    private void OnDisable()
    {
        Boomerang.OnEnemyDied -= Die;
    }

    private void Update()
    {
        if (player != null)
        {
            ChasePlayer();
        }
    }

    public void SetTarget(Transform target)
    {
        player = target;
    }

    private void ChasePlayer()
    {
        var distance = (player.position - transform.position);

        if (distance.magnitude > stopDistance)
        {
            enemyAnimator.SetBool("canShoot",false);

            LoookAtPlayer(distance);

            transform.Translate(transform.forward * (speed * Time.deltaTime), Space.World);
            
        }
        else
        {
            transform.LookAt(this.player);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            if (_timeCounter.IsTickFinished(Time.deltaTime))
            {
                enemyAnimator.SetBool("canShoot",true);
            }
        }
    }

    private void LoookAtPlayer(Vector3 distance)
    {
        Quaternion toRotation = Quaternion.LookRotation(distance, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    
    public void ShootAtPlayer()
    {
        enemyAnimator.SetBool("canShoot",true);
        var bulletObj = LeanPool.Spawn(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation,gameObject.transform);
        bulletObj.GetComponent<EnemyProjectile>().InitBullet(1,spawnPoint,transform);
    }

    public void Die()
    {
        _impulseSource.GenerateImpulse();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boomerang"))
        {
            Die();
            LeanPool.Despawn(this);
        }
    }
}

