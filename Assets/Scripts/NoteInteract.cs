using UnityEngine;
using UnityEngine.UI;

public class NoteInteract : MonoBehaviour
{
    public GameObject noteCanvas; // Reference to your note canvas GameObject
    public GameObject interactText; // Reference to the UI Text displaying the interact message
    public Button cancelButton; // Reference to the cancel button in the note canvas
    private bool canInteract = false; // Flag to track if player is in range to interact

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the canvas and interact text are initially disabled
        noteCanvas.SetActive(false);
        interactText.gameObject.SetActive(false);

        // Add listener for the cancel button
        cancelButton.onClick.AddListener(CancelInteraction);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in range to interact
        if (canInteract)
        {
            // Show the interact text prompting to press 'E'
            interactText.gameObject.SetActive(true);

            // Check if the player presses 'E' to toggle the canvas
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleNoteCanvas();
            }
        }
        else
        {
            // Hide the interact text when player is not in range
            interactText.gameObject.SetActive(false);
        }
    }

    // Method to toggle the note canvas visibility
    void ToggleNoteCanvas()
    {
        noteCanvas.SetActive(!noteCanvas.activeSelf);
        // Disable the interact text after showing the note canvas
        interactText.gameObject.SetActive(false);
    }

    // Method to handle cancel button click
    void CancelInteraction()
    {
        noteCanvas.SetActive(false);
        interactText.gameObject.SetActive(false);
    }

    // OnTriggerEnter2D is called when the Collider2D enters the trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    // OnTriggerExit2D is called when the Collider2D leaves the trigger zone
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            // Hide the interact text when player leaves the trigger zone
            interactText.gameObject.SetActive(false);
        }
    }

    // Ensure to clean up the button click listener when destroying the script or object
    private void OnDestroy()
    {
        cancelButton.onClick.RemoveListener(CancelInteraction);
    }
}
