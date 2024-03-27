using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUIHandler : MonoBehaviour
{
    [Header("Car details")]
    public Image carImage; // Reference to the image component for displaying the car image

    // Other components
    Animator animator = null; // Reference to the Animator component

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // Get the Animator component attached to any child object
    }

    // Start is called before the first frame update
    void Start()
    {
        // This method is currently empty and can be used for any initialization logic
    }

    // Sets up the car UI with the provided car data
    public void SetupCar(CarData carData)
    {
        carImage.sprite = carData.CarUISprite; // Set the sprite of the car image to the provided car UI sprite
    }

    // Starts the car entrance animation based on the specified direction
    public void StartCarEntranceAnimation(bool isAppearingOnRightSide)
    {
        if (isAppearingOnRightSide)
            animator.Play("Car UI Appear From Right"); // Play the animation for the car UI appearing from the right side
        else
            animator.Play("Car UI Appear From Left"); // Play the animation for the car UI appearing from the left side
    }

    // Starts the car exit animation based on the specified direction
    public void StartCarExitAnimation(bool isExitingOnRightSide)
    {
        if (isExitingOnRightSide)
            animator.Play("Car UI Disappear To Right"); // Play the animation for the car UI disappearing to the right side
        else
            animator.Play("Car UI Disappear To Left"); // Play the animation for the car UI disappearing to the left side
    }

    // Event called when the car exit animation is completed
    public void OnCarExitAnimationCompleted()
    {
        Destroy(gameObject); // Destroy the game object this script is attached to (in this case, the car UI)
    }
}