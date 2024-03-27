using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSign : MonoBehaviour
{
    // This script represents a parking sign in the Unity scene.

    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        // This method is called when a Collider enters the trigger area of this object.
        // It expects a Collider object as a parameter, which represents the other object that entered the trigger.

        Debug.Log("scan");
        // Outputs the message "scan" to the Unity console for debugging purposes.
        // This can be used to verify that the OnTriggerEnter method is being triggered correctly.

        GameManager.instance.OnRaceCompleted();
        // Calls the OnRaceCompleted() method of the GameManager instance.
        // GameManager is a singleton class that manages the game's logic, and this line indicates that the completion of a race event is being notified to the GameManager.
        // Make sure the GameManager instance exists and has the necessary method implemented.
    }
}