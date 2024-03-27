using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameStates { countDown, running, raceOver };

public class GameManager : MonoBehaviour
{
    // Static instance of GameManager so other scripts can access it
    public static GameManager instance = null;

    // States
    GameStates gameState = GameStates.countDown;

    // Time
    float raceStartedTime = 0;
    float raceCompletedTime = 0;

    // Events
    public event Action<GameManager> OnGameStateChanged;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            // If another instance of GameManager already exists, destroy this instance
            Destroy(gameObject);
            return;
        }

        // Make GameManager persistent across scene changes
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Empty Start method
    }

    // Method called when a level starts
    void LevelStart()
    {
        gameState = GameStates.countDown;

        Debug.Log("Level started");
    }

    // Get the current game state
    public GameStates GetGameState()
    {
        return gameState;
    }

    // Change the game state
    void ChangeGameState(GameStates newGameState)
    {
        if (gameState != newGameState)
        {
            gameState = newGameState;

            // Invoke the game state change event
            OnGameStateChanged?.Invoke(this);
        }
    }

    // Get the race time based on the current game state
    public float GetRaceTime()
    {
        if (gameState == GameStates.countDown)
            return 0;
        else if (gameState == GameStates.raceOver)
            return raceCompletedTime - raceStartedTime;
        else
            return Time.time - raceStartedTime;
    }

    // Method called when the race starts
    public void OnRaceStart()
    {
        Debug.Log("OnRaceStart");

        raceStartedTime = Time.time;

        ChangeGameState(GameStates.running);
    }

    // Method called when the race is completed
    public void OnRaceCompleted()
    {
        Debug.Log("OnRaceCompleted");

        raceCompletedTime = Time.time;

        ChangeGameState(GameStates.raceOver);
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Method called when a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Perform necessary actions when a new scene is loaded
        LevelStart();
    }
}