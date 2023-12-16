using System;
using Lean.Pool;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    [SerializeField] private VirtualJoystick virtualJoystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private GameObject powerupPath;
    [SerializeField] private GameObject gameOverPanel;
    
    private CharacterController characterController;
    private Vector3 moveVector;
    private GameStateManager gameStateManager;
    
    private void Awake()
    {
        Instance = this;
        characterController = GetComponent<CharacterController>();
        gameStateManager = GameStateManager.Instance;
    }

    private void OnEnable()
    {
        PlayerTriggerController.OnDied += HandlePlayerDied;
    }

    private void OnDisable()
    {
        PlayerTriggerController.OnDied -= HandlePlayerDied;
    }

    private void Update()
    {
        switch (gameStateManager.CurrentGameState)
        {
            case GameState.StartGame:
                if (Input.GetMouseButtonDown(0))
                {
                    gameStateManager.StartGame();
                }
                break;

            case GameState.Playing:
                moveSpeed = 100f;
                MovePlayer();
                break;

            case GameState.GameOver:
                gameStateManager.GameOver();
                moveSpeed = 0;
                break;
        }
    }
    
    private void MovePlayer()
    {
        moveVector = virtualJoystick.GetMovePosition() * (moveSpeed * Time.deltaTime / Screen.width);
        moveVector.z = moveVector.y;
        moveVector.y = 0;

        playerAnimator.ManageAnimations(moveVector);
        characterController.Move(moveVector);
    }

    public void EnablePowerUp()
    {
        GameObject newPowerup = LeanPool.Spawn(powerupPath, transform.position, Quaternion.identity);
        
    }

    private void HandlePlayerDied()
    {
        playerAnimator.PlayDeathAnimation();
        gameOverPanel.SetActive(true);
    }
}