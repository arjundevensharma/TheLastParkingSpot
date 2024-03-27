using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip musicClip; // The audio clip for the music
    public GameObject parkingSign; // Reference to the parking sign prefab

    private bool done = false; // Flag indicating if the operation is done
    private float waitTime; // The time to wait before performing an action
    private float timer = 0.0f; // The current timer value
    private bool loop = false; // Flag indicating if the loop should continue
    private float randomX; // Random X position
    private float randomY; // Random Y position

    private AudioSource audioSource; // Reference to the audio source component

    private void Start()
    {
        parkingSign = FindObjectOfType<ParkingSign>().gameObject; // Find the parking sign object in the scene
        parkingSign.transform.position = new Vector3(-100f, 0f, 0f); // Set the initial position of the parking sign
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this object
        audioSource.clip = musicClip; // Set the audio clip for the audio source
        audioSource.Play(); // Start playing the audio
        waitTime = UnityEngine.Random.Range(22.5f, 40.0f); // Set a random wait time between 22.5 and 40.0 seconds

        while (loop == false) {
            randomX = UnityEngine.Random.Range(-33.5f, 33.5f); // Generate a random X position
            randomY = UnityEngine.Random.Range(-17.4f, 13.4f); // Generate a random Y position

            // Check if the generated position is outside the restricted areas
            if (!(((-26.7 <= randomX && randomX <= -17.6) && (-14.7 <=randomY && randomY <= 6.6)) || 
                  ((-5.5 <= randomX && randomX <= 12.1) && (-20.9<=randomY && randomY <= -6.27)) || 
                  ((-23.6 <= randomX && randomX <= -8.5) && (-12.6<=randomY && randomY <= -1.9)) || 
                  ((-5.26 <= randomX && randomX <= 12.48) && (-5.81 <=randomY && randomY <= 4.56)) || 
                  ((13.23 <= randomX && randomX <= 24.84) && (-7.2 <=randomY && randomY <= 4.56)))) {
                loop = true; // Exit the loop if the position is valid
            } 
        }
    }

    private void Update()
    {
        timer += Time.deltaTime; // Update the timer with the elapsed time since the last frame

        if (timer > waitTime && done == false) {
            audioSource.Stop(); // Stop playing the audio
            parkingSign.transform.position = new Vector3(randomX, randomY, 0f); // Set the position of the parking sign to the generated random position
            done = true; // Mark the operation as done
        }
    }
}

/*

Code segments that may be useful in future iterations of the game, but aren't used as of current
    private void SpawnParkingSpot()
    {
       GameObject parkingSign = Instantiate(parkingSignPrefab); // Instantiate the parking sign prefab
        parkingSign.transform.position = GetRandomPosition(); // Use the correct method name
    }
/*
    private Vector3 GetRandomPosition()
    {
       /* // Customize this function to get a random position within your game world
        // For example, you can use Random.Range to get random x and y coordinates
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        return new Vector3(randomX, randomY, 0f);
        */