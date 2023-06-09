using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    public Canvas StartScreen, DeathScreen, VictroyScreen;
    public GameObject Player, DebrisSpawner, EnemySpawner;

    private void Awake()
    {
        instance = this;
        updateGameState(GameState.StartMenu);
    }

    void Start()
    {
        updateGameState(GameState.StartMenu);
    }

    private void Update()
    {
        if (Player.GetComponent<PlayerHeaalth>().PlayersHeaalth < 1f)
        {
            updateGameState(GameState.Lost);
        }
    }

    public void updateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.StartMenu:
                HandleStartGame();
                break;
            case GameState.Playing:
                HandlePlayingGame();
                break;
            case GameState.Lost:
                HandleGameLost();
                break;
            case GameState.Won:
                HandleGameWon();
                /*Once the player gets all the upgrade then show a win screen*/
                break;
        }

        OnGameStateChanged?.Invoke(newState);

    }

    private void HandleStartGame()
    {
        StartScreen.GetComponent<Canvas>().enabled = true;
        DeathScreen.GetComponent<Canvas>().enabled = false;
        VictroyScreen.GetComponent<Canvas>().enabled = false;

        Player.GetComponent<PlayerMovementController>().enabled = false;
        Player.GetComponentInChildren<baseWeapon>().enabled = false;

        DebrisSpawner.GetComponent<DebrisSpawnner>().enabled = false;
        EnemySpawner.GetComponent<EnemySpawnner>().enabled = false;
    }

    private void HandlePlayingGame()
    {
        StartScreen.GetComponent<Canvas>().enabled = false;
        DeathScreen.GetComponent<Canvas>().enabled = false;
        VictroyScreen.GetComponent<Canvas>().enabled = false;

        Player.GetComponent<PlayerMovementController>().enabled = true;
        Player.GetComponentInChildren<baseWeapon>().enabled = true;

        DebrisSpawner.GetComponent<DebrisSpawnner>().enabled = true;
        EnemySpawner.GetComponent<EnemySpawnner>().enabled = true;
    }

    private void HandleGameLost()
    {
        StartScreen.GetComponent<Canvas>().enabled = false;
        DeathScreen.GetComponent<Canvas>().enabled = true;
        VictroyScreen.GetComponent<Canvas>().enabled = false;

        Player.GetComponent<PlayerMovementController>().enabled = false;
        Player.GetComponentInChildren<baseWeapon>().enabled = false;

        DebrisSpawner.GetComponent<DebrisSpawnner>().enabled = false;
        EnemySpawner.GetComponent<EnemySpawnner>().enabled = false;
    }

    private void HandleGameWon()
    {
        StartScreen.GetComponent<Canvas>().enabled = false;
        DeathScreen.GetComponent<Canvas>().enabled = false;
        VictroyScreen.GetComponent<Canvas>().enabled = true;

        Player.GetComponent<PlayerMovementController>().enabled = false;
        Player.GetComponentInChildren<baseWeapon>().enabled = false;

        DebrisSpawner.GetComponent<DebrisSpawnner>().enabled = false;
        EnemySpawner.GetComponent<EnemySpawnner>().enabled = false;
    }

    public void StartGame()
    {
        updateGameState(GameState.Playing);
        Debug.Log("Game Started!");
    }

    public enum GameState
    {
        StartMenu,
        Playing,
        Lost,
        Won
    }
}
