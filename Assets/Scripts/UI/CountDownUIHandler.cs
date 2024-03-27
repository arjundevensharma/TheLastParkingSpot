using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownUIHandler : MonoBehaviour
{
    public Text countDownText;  // Reference to the Text component for displaying the countdown

    private void Awake()
    {
        countDownText.text = "";  // Clear the initial text of the countdown
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownCO());  // Start the below coroutine for the countdown
    }

    IEnumerator CountDownCO()
    {
        yield return new WaitForSeconds(0.3f);  // Wait for 0.3 seconds before starting the countdown

        int counter = 3;  // Initialize the counter to 3

        while (true)
        {
            if (counter != 0)
                countDownText.text = counter.ToString();  // Update the countdown text with the current value of the counter (3... 2... 1...)
            else
            {
                countDownText.text = "GO";  // Set the countdown text to "GO" when counter reaches 0

                GameManager.instance.OnRaceStart();  // Call the OnRaceStart() method in the GameManager

                break;  // Exit the loop
            }

            counter--;  // Decrement the counter
            yield return new WaitForSeconds(1.0f);  // Wait for 1 second before updating the counter
        }

        yield return new WaitForSeconds(0.5f);  // Wait for 0.5 seconds after the countdown finishes

        gameObject.SetActive(false);  // Deactivate the game object this script is attached to
    }
}