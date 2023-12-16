using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{  
    [SerializeField] private float rotationSpeed = 3f;
    private ICollectable collectableImplementation;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0,rotationSpeed,0);
    }

    public void Collect()
    {
        collectableImplementation.Collect();
    }
}
