using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimeUIHandler : MonoBehaviour
{
    Text timeText; // Reference to the Text component for displaying race time.

    float lastRaceTimeUpdate = 0; // Last recorded race time update.

    private void Awake()
    {
        timeText = GetComponent<Text>(); // Get the Text component attached to the same GameObject.
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTimeCO()); // Start the coroutine for updating the race time.
    }

    IEnumerator UpdateTimeCO()
    {
        while (true)
        {
            float raceTime = GameManager.instance.GetRaceTime(); // Get the current race time from the GameManager.

            if (lastRaceTimeUpdate != raceTime)
            {
                int raceTimeMinutes = (int)Mathf.Floor(raceTime / 60); // Calculate the minutes portion of the race time.
                int raceTimeSeconds = (int)Mathf.Floor(raceTime % 60); // Calculate the seconds portion of the race time.

                // Format the race time as a string in the format "MM:SS" and assign it to the Text component.
                timeText.text = $"{raceTimeMinutes.ToString("00")}:{raceTimeSeconds.ToString("00")}";

                lastRaceTimeUpdate = raceTime; // Update the last recorded race time.
            }

            yield return new WaitForSeconds(0.1f); // Wait for a short duration before checking the race time again.
        }
    }
}