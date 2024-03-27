using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLeaderboardItemInfo : MonoBehaviour
{
    public Text positionText; // Reference to the Text component for displaying the position
    public Text driverNameText; // Reference to the Text component for displaying the driver name

    // Start is called before the first frame update
    void Start()
    {
        // Code to initialize or perform any necessary setup when the script starts
    }

    // Method for setting the position text
    public void SetPositionText(string newPosition)
    {
        positionText.text = newPosition; // Update the positionText with the provided new position
    }

    // Method for setting the driver name text
    public void SetDriverNameText(string newDriverName)
    {
        driverNameText.text = newDriverName; // Update the driverNameText with the provided new driver name
    }
}