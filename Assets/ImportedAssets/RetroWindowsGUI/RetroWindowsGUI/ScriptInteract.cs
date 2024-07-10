using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ScriptInteract : MonoBehaviour
{
    public GameObject myPC;             // Reference to the PC object
    public GameObject text;             // Reference to the text object
    public GameObject StartaftermyPC;   // Reference to the new game object
    public GameObject puzzleCanvas;     // Reference to the puzzle UI canvas
    public Button cancelButton;         // Reference to the cancel button in the puzzle canvas
    public GameObject inputText;        // Reference to the GameObject containing the TMP_Text component for the puzzle input
    public string correctNumber = "15324"; // Correct number sequence for the puzzle
    public GameObject RewardCanvas;     // Reference to the reward canvas
    public Button rewardCancelButton;   // Reference to the cancel button in the reward canvas

    private bool canInteractWithStartaftermyPC = false; // Flag to determine if the player can interact with StartaftermyPC
    private bool playerInCollider = false; // Flag to check if the player is within the collider
    private string currentInput = ""; // Current input string
    private TMP_Text inputTextComponent; // Reference to the TMP_Text component
    public InteractableEvent[] onRewardCancel;
    public UnityEvent onPuzzleActivate; // Event for when the puzzle is activated
    public UnityEvent onCorrectPassword; // Event for when the correct password is entered

    void Start()
    {
        InitializeComponents();
    }
  
    void InitializeComponents()
    {
        // Deactivate unnecessary components initially
        if (text != null)
        {
            text.SetActive(false);
        }
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(false);
        }
        if (StartaftermyPC != null)
        {
            StartaftermyPC.SetActive(false);
        }
        if (RewardCanvas != null)
        {
            RewardCanvas.SetActive(false);
        }


        // Setup button listeners
        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(CancelPuzzle);
        }
        if (rewardCancelButton != null)
        {
            rewardCancelButton.onClick.AddListener(CloseRewardCanvas);
        }

        // Get the TMP_Text component from the inputText GameObject
        if (inputText != null)
        {
            inputTextComponent = inputText.GetComponent<TMP_Text>();
        }

        // Ensure the input text is initially empty
        if (inputTextComponent != null)
        {
            inputTextComponent.text = "";
        }
    }

    void Update()
    {
        // Ensure interaction happens only when the player is within the collider and presses the E key
        if (playerInCollider && canInteractWithStartaftermyPC && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithStartaftermyPC();
        }
    }

    public void ActivateInteractionText()
    {
        // Enable the StartaftermyPC object for interaction
        if (StartaftermyPC != null)
        {
            StartaftermyPC.SetActive(true);
        }

        canInteractWithStartaftermyPC = true;
    }

    public void ActivatePuzzle()
    {
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(true);
        }

        // Trigger the puzzle activate event if connected
        if (onPuzzleActivate != null)
        {
            onPuzzleActivate.Invoke();
        }
    }

    void InteractWithStartaftermyPC()
    {
        // Enable the puzzle canvas
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(true);
        }

        // Disable the interaction text
        if (text != null)
        {
            text.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;

            if (canInteractWithStartaftermyPC && text != null)
            {
                text.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;

            if (text != null)
            {
                text.SetActive(false);
            }
        }
    }

    void CancelPuzzle()
    {
        // Deactivate the puzzle canvas
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(false);
        }

        // Re-enable the StartaftermyPC object for interaction
        if (StartaftermyPC != null)
        {
            StartaftermyPC.SetActive(true);
        }

        ResetInput();
        Debug.Log("Puzzle canceled");
    }

    public void CloseRewardCanvas()
    {
        // Deactivate the reward canvas
        if (RewardCanvas != null)
        {
            RewardCanvas.SetActive(false);
        }

        // Deactivate the puzzle canvas if it's still active
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(false);
        }

        // Disable interaction with StartaftermyPC
        if (StartaftermyPC != null)
        {
            StartaftermyPC.SetActive(false);
        }

        // Reset the input field
        ResetInput();

        // Trigger the reward cancel event if connected
        if (onRewardCancel != null)
        {
            TriggerEvents();
        }

        // Additional logic as needed when closing the reward canvas
        Debug.Log("Reward canvas closed");

        // Example of what to do after cancelling the reward canvas
        ExampleMethodOnRewardCancel();
    }

    // Example method called after cancelling the reward canvas
    void TriggerEvents()
    {
        //invoke every event
        foreach (InteractableEvent interactableEvent in onRewardCancel)
        {
            Debug.Log("Event: " + interactableEvent.eventName);
            interactableEvent.unityEvent.Invoke();
        }
    }

    void ExampleMethodOnRewardCancel()
    {
        // Insert your logic here for actions to take after cancelling the reward canvas
        Debug.Log("Example method called after cancelling the reward canvas");
    }

    // Function to be called by each button
    public void ButtonPressed(string number)
    {
        // Add the number pressed to the current input
        currentInput += number;

        // Update the displayed input text
        if (inputTextComponent != null)
        {
            inputTextComponent.text = currentInput;
        }

        // Check if the current input matches the correct number
        if (currentInput.Length == correctNumber.Length)
        {
            CheckInput();
        }
    }

    // Function to check if the input is correct
    public void CheckInput()
    {
        if (currentInput == correctNumber)
        {
            RewardCanvas.SetActive(true);

            // Trigger the correct password event if connected
            if (onCorrectPassword != null)
            {
                onCorrectPassword.Invoke();
            }
        }
        else
        {
            // Incorrect input, perform failure action
            Debug.Log("Incorrect number entered!");
            ResetInput();
        }
    }

    // Function to reset the current input
    private void ResetInput()
    {
        currentInput = "";
        if (inputTextComponent != null)
        {
            inputTextComponent.text = "";
        }
    }
}
