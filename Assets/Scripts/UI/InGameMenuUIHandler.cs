using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuUIHandler : MonoBehaviour
{
    //Other components
    Canvas canvas;

    private void Awake()
    {
        // Get the Canvas component attached to this game object
        canvas = GetComponent<Canvas>();

        // Disable the canvas initially
        canvas.enabled = false;

        // Hook up the OnGameStateChanged event to the GameManager's event
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }
   

    public void OnRaceAgain()
    {
        // Load the current scene again to restart the race
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitToMainMenu()
    {
        // Load the "Menu" scene to go back to the main menu
        SceneManager.LoadScene("Menu");
    }

    IEnumerator ShowMenuCO()
    {
        // Wait for 1 second before showing the menu
        yield return new WaitForSeconds(1);

        // Enable the canvas to show the menu
        canvas.enabled = true;
    }

    // Event handler for the OnGameStateChanged event
    void OnGameStateChanged(GameManager gameManager)
    {
        // Check if the game state is "raceOver"
        if (GameManager.instance.GetGameState() == GameStates.raceOver)
        {
            // Start the coroutine to show the menu
            StartCoroutine(ShowMenuCO());
        }
    }

    void OnDestroy()
    {
        // Unhook the OnGameStateChanged event when the script is destroyed
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }
}