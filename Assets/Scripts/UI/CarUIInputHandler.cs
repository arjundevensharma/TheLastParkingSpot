using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUIInputHandler : MonoBehaviour
{
    CarInputHandler playerCarInputHandler; // Reference to the CarInputHandler script that handles car input

    Vector2 inputVector = Vector2.zero; // Stores the input vector for the car's movement (acceleration, braking, steering)

    private void Awake()
    {
        CarInputHandler[] carinputHandlers = FindObjectsOfType<CarInputHandler>(); // Find all instances of the CarInputHandler script in the scene

        foreach (CarInputHandler carInputHandler in carinputHandlers) // Loop through each CarInputHandler instance
        {
            if (carInputHandler.isUIInput) // Check if the CarInputHandler is specifically for UI input
            {
                playerCarInputHandler = carInputHandler; // Assign the CarInputHandler as the player's car input handler
                break; // Exit the loop since we found the player's car input handler
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // This method is currently empty and does not contain any code
    }

    public void OnAcceleratePress()
    {
        inputVector.y = 1.0f; // Set the vertical input to accelerate (positive value)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }

    public void OnBrakePress()
    {
        inputVector.y = -1.0f; // Set the vertical input to brake (negative value)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }

    public void OnAccelerateBrakRelease()
    {
        inputVector.y = 0.0f; // Reset the vertical input to zero (no acceleration or braking)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }

    public void OnSteerLeftPress()
    {
        inputVector.x = -1.0f; // Set the horizontal input to steer left (negative value)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }

    public void OnSteerRightPress()
    {
        inputVector.x = 1.0f; // Set the horizontal input to steer right (positive value)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }

    public void OnSteerRelease()
    {
        inputVector.x = 0.0f; // Reset the horizontal input to zero (no steering)
        playerCarInputHandler.SetInput(inputVector); // Pass the input vector to the player's car input handler
    }
}