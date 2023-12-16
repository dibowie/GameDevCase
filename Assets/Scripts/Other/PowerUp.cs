using Lean.Pool;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject portalVFX;
    private GameObject vfxInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Start()
    {
        SpawnVfx();
    }

    private void SpawnVfx()
    {
        vfxInstance = Instantiate(portalVFX, transform.position + Vector3.up * 2, Quaternion.Euler(90, 0, 0));
    }

    private void Collect()
    {
        PlayerController.Instance.EnablePowerUp();
        LeanPool.Despawn(vfxInstance);
        gameObject.SetActive(false);
    }
}