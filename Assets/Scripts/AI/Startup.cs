using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class responsible for starting up the game
public class Startup
{
    // Method that is automatically called before the scene is loaded
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InstantiatePrefabs()
    {
        // Display a debug log message to indicate that object instantiation is starting
        Debug.Log("-- Instantiating objects --");

        // Load all the prefabs from the specified folder path
        GameObject[] prefabsToInstantiate = Resources.LoadAll<GameObject>("InstantiateOnLoad/");

        // Iterate through each prefab in the array
        foreach (GameObject prefab in prefabsToInstantiate)
        {
            // Display a debug log message to indicate the creation of a prefab
            Debug.Log($"Creating {prefab.name}");

            // Instantiate the prefab in the scene
            GameObject.Instantiate(prefab);
        }

        // Display a debug log message to indicate that object instantiation is done
        Debug.Log("-- Instantiating objects done --");
    }
}