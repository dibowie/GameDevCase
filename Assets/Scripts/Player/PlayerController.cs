using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private VirtualJoystick virtualJoystick;
    [SerializeField] private float moveSpeed; 
    [SerializeField] private PlayerAnimator playerAnimator;
        
    private CharacterController _characterController;
    private Vector3 _moveVector;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        _moveVector = virtualJoystick.GetMovePosition() * moveSpeed * Time.deltaTime / Screen.width;
        _moveVector.z = _moveVector.y;
        _moveVector.y = 0;

        playerAnimator.ManageAnimations(_moveVector);
        _characterController.Move(_moveVector);
    }
}
