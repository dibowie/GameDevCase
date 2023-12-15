using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{       
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyProjectile"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("hit");
        }
        if (other.transform.CompareTag("Enemy"))
        {
            Debug.Log("EnemyTouched");
            //player die
        }
    }
}
