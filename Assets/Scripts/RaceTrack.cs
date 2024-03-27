using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrack : MonoBehaviour
{
    public GameObject raceTrack; // Reference to the race track GameObject
    private float timer = 0.0f; // Timer for tracking elapsed time
    private float waitTime = 22.5f; // Time to wait before performing an action

    // Start is called before the first frame update
    void Start()
    {
        raceTrack.GetComponent<BoxCollider2D>().enabled = true; // Enable the BoxCollider2D component on the race track GameObject
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Check if the colliding object has the "Player" tag and if enough time has passed
        if (col.gameObject.tag == "Player" && timer > waitTime)
        {
            // Perform an action when the conditions are met
            // raceTrack.GetComponent<BoxCollider2D>().enabled = false; // Disable the BoxCollider2D component on the race track GameObject
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer based on the time elapsed since the last frame
        timer += Time.deltaTime;
    }
}