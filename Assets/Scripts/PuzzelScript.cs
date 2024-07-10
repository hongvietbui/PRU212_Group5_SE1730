using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelScript : MonoBehaviour
{
    public GameObject inputText; // Reference to the GameObject containing the Text component
    public string correctNumber = "123456789"; // Correct number sequence
    private string currentInput = ""; // Current input string
    private Text inputTextComponent; // Reference to the Text component

    void Start()
    {
        // Get the Text component from the inputText GameObject
        if (inputText != null)
        {
            inputTextComponent = inputText.GetComponent<Text>();
            if (inputTextComponent == null)
            {
                Debug.LogError("Text component not found on inputText GameObject.");
            }
        }
        else
        {
            Debug.LogError("inputText GameObject is not assigned.");
        }

        // Ensure the input text is initially empty
        if (inputTextComponent != null)
        {
            inputTextComponent.text = "";
        }
    }

    // Function to be called by each button
    public void ButtonPressed(string number)
    {
        Debug.Log("Button pressed: " + number);

        // Add the number pressed to the current input
        currentInput += number;

        // Update the displayed input text
        if (inputTextComponent != null)
        {
            inputTextComponent.text = currentInput;
            Debug.Log("Current input text: " + inputTextComponent.text);
        }

        // Check if the current input matches the correct number
        if (currentInput.Length == correctNumber.Length)
        {
            CheckInput();
        }
    }

    // Function to check if the input is correct
    private void CheckInput()
    {
        Debug.Log("Checking input: " + currentInput);

        if (currentInput == correctNumber)
        {
            // Correct input, perform success action
            Debug.Log("Correct number entered!");
            // Add your success logic here (e.g., enable a new canvas, show a message, etc.)
        }
        else
        {
            // Incorrect input, perform failure action
            Debug.Log("Incorrect number entered!");
            // Add your failure logic here (e.g., show an error message, reset input, etc.)
            ResetInput();
        }
    }

    // Function to reset the current input
    private void ResetInput()
    {
        Debug.Log("Resetting input");

        currentInput = "";
        if (inputTextComponent != null)
        {
            inputTextComponent.text = "";
        }
    }

    // Function to be called by the cancel button
    public void Cancel()
    {
        Debug.Log("Cancel button pressed");
        ResetInput();
    }
}
