using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CarLapCounter : MonoBehaviour
{
    public Text carPositionText; // Text component to display the car's position
    public GameObject parkingSign; // Storing the parking sign game object

    void Start ()
    {
        parkingSign = FindObjectOfType<ParkingSign>().gameObject; // Find and assign the parking sign game object
    }

    void Update ()
    {
        //no updating
    }

    float timeAtLastPassedCheckPoint = 0; // Time at the last passed checkpoint
    int numberOfPassedCheckpoints = 0; // Number of passed checkpoints
    bool isRaceCompleted = false; // Flag to indicate if the race is completed
    int carPosition = 0; // Position of the car in the race
    bool isHideRoutineRunning = false; // Flag to indicate if the hide routine is running
    float hideUIDelayTime; // Delay time for hiding the UI

    // Events
    public event Action<CarLapCounter> OnPassCheckpoint; // Event triggered when a checkpoint is passed

    public void SetCarPosition(int position)
    {
        carPosition = position; // Set the car's position
    }

    public int GetNumberOfCheckpointsPassed()
    {
        return numberOfPassedCheckpoints; // Return the number of passed checkpoints
    }

    public float GetTimeAtLastCheckPoint()
    {
        return timeAtLastPassedCheckPoint; // Return the time at the last passed checkpoint
    }

    IEnumerator ShowPositionCO(float delayUntilHidePosition)
    {
        hideUIDelayTime += delayUntilHidePosition; // Update the hide UI delay time

        carPositionText.text = carPosition.ToString(); // Display the car's position on the text component

        if (!isHideRoutineRunning) // If the hide routine is not already running
        {
            isHideRoutineRunning = true; // Mark the hide routine as running

            yield return new WaitForSeconds(hideUIDelayTime); // Wait for the hide UI delay time

            isHideRoutineRunning = false; // Mark the hide routine as not running
        }
    }

    //when one of the cars collides with the parking sign:
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //making sure the collision was with the parking sign
        if (collider2D.CompareTag("ParkingSign"))
        {
            // Move the parking sign off the map
            parkingSign.transform.position = new Vector3(69f, 69f, 69f);

            // For debugging
            if (isRaceCompleted)
                return;

            // Mark the race as completed
            isRaceCompleted = true;

            // Invoke the event for passing a checkpoint (formulative event)
            OnPassCheckpoint?.Invoke(this);

            // If the race is completed, execute additional actions
            if (isRaceCompleted)
            {
                // Start a coroutine to show the final position (100 is just a placeholder)
                StartCoroutine(ShowPositionCO(100));

                // Making sure the object triggering the event is one of the 2 cars (they are assigned the "Player" tag)
                if (CompareTag("Player"))
                {
                    // Call the GameManager's OnRaceCompleted state which will show the game over screen
                    GameManager.instance.OnRaceCompleted();

                    // What these lines essentially signify is that the car of the player that has won the game is now operated by an AI engine
                    GetComponent<CarInputHandler>().enabled = false;
                    GetComponent<CarAIHandler>().enabled = true;
                    GetComponent<AStarLite>().enabled = true;
                }
            }
        }
    }
    
}

//The following comments comprise code segments that were never used in the code, but may prove useful for future versions of this game:

 //int passedCheckPointNumber = 0;
/*
    int lapsCompleted = 0;
    const int lapsToComplete = 2;
*/
        //-34.5f, 34.5, -19.8f, 19.8f

            //parkingSign.transform.position = new Vector3(UnityEngine.Random.Range(-34.5f, 34.5f), UnityEngine.Random.Range(-19.8f, 19.8f), 0f);

/*if (collider2D.CompareTag("ParkingSign")) 
        {
            if (isRaceCompleted)
                return;

            ParkingSign checkPoint = collider2D.GetComponent<ParkingSign>();

            isRaceCompleted = true; 
            OnPassCheckpoint?.Invoke(this);

            StartCoroutine(ShowPositionCO(100));
            GameManager.instance.OnRaceCompleted();

                        GetComponent<CarInputHandler>().enabled = false;
                        GetComponent<CarAIHandler>().enabled = true;
                        GetComponent<AStarLite>().enabled = true;
                    }
                }
                else if (checkPoint.isFinishLine) StartCoroutine(ShowPositionCO(1.5f));

        }
        */

        
            /*
            CheckPoint checkPoint = collider2D.GetComponent<CheckPoint>();
            
            //Make sure that the car is passing the checkpoints in the correct order. The correct checkpoint must have exactly 1 higher value than the passed checkpoint
            if (passedCheckPointNumber + 1 == checkPoint.checkPointNumber)
            {
                passedCheckPointNumber = checkPoint.checkPointNumber;

                numberOfPassedCheckpoints++;

                //Store the time at the checkpoint
                timeAtLastPassedCheckPoint = Time.time;

                if (checkPoint.isFinishLine)
                {
                    passedCheckPointNumber = 0;
                    lapsCompleted++; 
                    
                    if (lapsCompleted >= lapsToComplete)
                        isRaceCompleted = true;
                }

                //Invoke the passed checkpoint event
                OnPassCheckpoint?.Invoke(this);

                //Now show the cars position as it has been calculated but only do it when a car passes through the finish line
                if (isRaceCompleted)
                {
                    StartCoroutine(ShowPositionCO(100));

                    if (CompareTag("Player"))
                    {
                        GameManager.instance.OnRaceCompleted();

                        GetComponent<CarInputHandler>().enabled = false;
                        GetComponent<CarAIHandler>().enabled = true;
                        GetComponent<AStarLite>().enabled = true;
                    }
                }
                else if (checkPoint.isFinishLine) StartCoroutine(ShowPositionCO(1.5f));
            }
            */