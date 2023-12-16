using UnityEngine;

public class Coin : MonoBehaviour
{  
    [SerializeField] private float rotationSpeed = 3f; 
    
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0,rotationSpeed,0);
    }
    
}
