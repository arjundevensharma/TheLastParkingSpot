using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find all game objects with the "SpawnPoint" tag
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        // Load all car data from the "CarData/" folder
        CarData[] carDatas = Resources.LoadAll<CarData>("CarData/");

        // Iterate through each spawn point
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Get the transform of the current spawn point
            Transform spawnPoint = spawnPoints[i].transform;

            // Get the ID of the car selected by the player
            int playerSelectedCarID = PlayerPrefs.GetInt($"P{i + 1}SelectedCarID");

            // Find the selected car in the loaded car data
            foreach (CarData cardata in carDatas)
            {
                // Check if the current car data matches the selected car ID for the player
                if (cardata.CarUniqueID == playerSelectedCarID)
                {
                    // Spawn the selected car at the spawn point
                    GameObject car = Instantiate(cardata.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                    // Determine the player number based on the loop index
                    int playerNumber = i + 1;

                    // Set the player number for car input handling
                    car.GetComponent<CarInputHandler>().playerNumber = i + 1;

                    // Check if the player is an AI-controlled car
                    if (PlayerPrefs.GetInt($"P{playerNumber}_IsAI") == 1)
                    {
                        // Disable AI-related components and set the car's tag as "Player" AKA controlled by player not AI. I thought a 2-player demonstration would be more interactive than the original intent of the game design as a player vs. computer demonstration
                        car.GetComponent<CarAIHandler>().enabled = false;
                        car.GetComponent<AStarLite>().enabled = false;
                        car.tag = "Player";
                    }
                    else
                    {
                        // Disable AI-related components and set the car's tag as "Player" AKA controlled by player not AI. I thought a 2-player demonstration would be more interactive than the original intent of the game design as a player vs. computer demonstration
                        car.GetComponent<CarAIHandler>().enabled = false;
                        car.GetComponent<AStarLite>().enabled = false;
                        car.tag = "Player";
                    }

                    // Exit the loop after finding the selected car
                    break;
                }
            }
        }
    }
}