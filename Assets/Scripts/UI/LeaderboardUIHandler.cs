using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUIHandler : MonoBehaviour
{
    public GameObject leaderboardItemPrefab; // Prefab for the leaderboard item

    SetLeaderboardItemInfo[] setLeaderboardItemInfo; // Array to store leaderboard item information

    bool isInitilized = false; // Flag to check if the leaderboard is initialized

    // Other components
    Canvas canvas; // Reference to the Canvas component

    void Awake()
    {
        canvas = GetComponent<Canvas>(); // Get the Canvas component attached to the GameObject
        canvas.enabled = false; // Disable the Canvas initially

        // Hook up events
        GameManager.instance.OnGameStateChanged += OnGameStateChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        VerticalLayoutGroup leaderboardLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>(); // Get the VerticalLayoutGroup component attached to the GameObject or any of its children

        // Get all Car lap counters in the scene
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>(); // Find all objects with the CarLapCounter component in the scene

        // Allocate the array
        setLeaderboardItemInfo = new SetLeaderboardItemInfo[carLapCounterArray.Length]; // Create an array of SetLeaderboardItemInfo objects with the same length as the carLapCounterArray

        // Create the leaderboard items
        for (int i = 0; i < carLapCounterArray.Length; i++)
        {
            // Set the position
            GameObject leaderboardInfoGameObject = Instantiate(leaderboardItemPrefab, leaderboardLayoutGroup.transform); // Instantiate a new leaderboard item GameObject using the prefab and attach it to the leaderboardLayoutGroup

            setLeaderboardItemInfo[i] = leaderboardInfoGameObject.GetComponent<SetLeaderboardItemInfo>(); // Get the SetLeaderboardItemInfo component attached to the leaderboard item GameObject

            setLeaderboardItemInfo[i].SetPositionText($"{i + 1}."); // Set the position text of the leaderboard item
        }

        Canvas.ForceUpdateCanvases(); // Force update the Canvas to reflect the changes

        isInitilized = true; // Set the initialized flag to true
    }

    public void UpdateList(List<CarLapCounter> lapCounters)
    {
        if (!isInitilized)
            return;

        // Update the leaderboard items with driver names
        for (int i = 0; i < lapCounters.Count; i++)
        {
            setLeaderboardItemInfo[i].SetDriverNameText(lapCounters[i].gameObject.name); // Set the driver name text of the leaderboard item based on the lapCounters list
        }
    }

    // Events 
    void OnGameStateChanged(GameManager gameManager)
    {
        if (GameManager.instance.GetGameState() == GameStates.raceOver)
        {
            canvas.enabled = true; // Enable the Canvas when the game state changes to "raceOver"
        }
    }

    void OnDestroy()
    {
        // Unhook events
        GameManager.instance.OnGameStateChanged -= OnGameStateChanged;
    }
}