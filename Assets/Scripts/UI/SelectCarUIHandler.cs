// Import necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCarUIHandler : MonoBehaviour
{
    [Header("Car prefab")]
    public GameObject carPrefab; // Reference to the car prefab that will be spawned

    [Header("Spawn on")]
    public Transform spawnOnTransform; // Transform where the car will be spawned

    bool isChangingCar = false; // Flag to track if the car is currently changing

    CarData[] carDatas; // Array to hold the car data

    int selectedCarIndex = 0; // Index of the currently selected car

    // Other components
    CarUIHandler carUIHandler = null; // Reference to the CarUIHandler component

    // Start is called before the first frame update
    void Start()
    {
        // Load the car data from the resources folder
        carDatas = Resources.LoadAll<CarData>("CarData/");

        // Start the coroutine to spawn the car
        StartCoroutine(SpawnCarCO(true));
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left arrow key press to select the previous car
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnPreviousCar();
        }
        // Check for right arrow key press to select the next car
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnNextCar();
        }

        // Check for space key press to select the current car
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectCar();
        }
    }

    // Method to handle selecting the previous car
    public void OnPreviousCar()
    {
        if (isChangingCar)
            return;

        // Decrement the selected car index
        selectedCarIndex--;

        // Wrap around to the last car if the index goes below zero
        if (selectedCarIndex < 0)
            selectedCarIndex = carDatas.Length - 1;

        // Start the coroutine to spawn the car
        StartCoroutine(SpawnCarCO(true));
    }

    // Method to handle selecting the next car
    public void OnNextCar()
    {
        if (isChangingCar)
            return;

        // Increment the selected car index
        selectedCarIndex++;

        // Wrap around to the first car if the index goes beyond the array length
        if (selectedCarIndex > carDatas.Length - 1)
            selectedCarIndex = 0;

        // Start the coroutine to spawn the car
        StartCoroutine(SpawnCarCO(false));
    }

    // Method to handle selecting the current car
    public void OnSelectCar()
    {
        // Save the selected car and AI settings in player preferences
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.SetInt("P1_IsAI", 0);

        // Select random cars for AI players
        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P2_IsAI", 1);

        PlayerPrefs.SetInt("P3SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P3_IsAI", 1);

        PlayerPrefs.SetInt("P4SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P4_IsAI", 1);

        // Save the player preferences
        PlayerPrefs.Save();

        // Load the "Course1" scene
        SceneManager.LoadScene("Course1");
    }

    // Coroutine to spawn the car
    IEnumerator SpawnCarCO(bool isCarAppearingOnRightSide)
    {
        // Set the flag to indicate that the car is changing
        isChangingCar = true;

        // Start the car exit animation if there is a previous car
        if (carUIHandler != null)
            carUIHandler.StartCarExitAnimation(!isCarAppearingOnRightSide);

        // Instantiate the car prefab at the specified transform
        GameObject instantiatedCar = Instantiate(carPrefab, spawnOnTransform);

        // Get the CarUIHandler component of the instantiated car
        carUIHandler = instantiatedCar.GetComponent<CarUIHandler>();

        // Set up the car UI with the data of the selected car
        carUIHandler.SetupCar(carDatas[selectedCarIndex]);

        // Start the car entrance animation
        carUIHandler.StartCarEntranceAnimation(isCarAppearingOnRightSide);

        // Wait for a short delay
        yield return new WaitForSeconds(0.4f);

        // Set the flag to indicate that the car change is complete
        isChangingCar = false;
    }
}