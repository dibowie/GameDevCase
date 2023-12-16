using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    StartGame,
    Playing,
    GameOver
}
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public GameState CurrentGameState { get; private set; } = GameState.StartGame;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        CurrentGameState = GameState.Playing;
    }

    public void GameOver()
    {
        CurrentGameState = GameState.GameOver;
    }
}