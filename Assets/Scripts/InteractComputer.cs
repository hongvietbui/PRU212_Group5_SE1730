using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace narrenschlag.dialoguez
{
    public class InteractComputer : MonoBehaviour
    {
        public Canvas interactCanvas;       // Reference to the Canvas to show/hide
        public GameObject interactText;     // Reference to the UI Text displaying the interact message
        public Image animationImage;        // Reference to the Image component with animation
        public Sprite[] animationFrames;    // Array of sprites for animation frames
        public float frameDuration = 0.1f;  // Duration between frames
        public KeyCode interactKey = KeyCode.E; // Key to interact (E key by default)
        public GameObject mypcs;            // Reference to the PC object to disable its collider
        public Canvas dialogueCanvas;       // Reference to the dialogue canvas
        public GameObject playerObject;     // Reference to the player object to disappear
        public DialogueZ dialogueManager;   // Reference to the DialogueZ component
        public string dialogueIdFirst;      // ID of the first dialogue to start
        public string dialogueIdLast;       // ID of the last dialogue to end
        public GameObject puzzleCanvas;     // Reference to the puzzle UI canvas

        private bool playerInRange = false; // Flag to track if player is in range for interaction
        private bool isInteracting = false; // Flag to track if interaction is ongoing
        private string currentDialogueId;   // Tracks the current dialogue ID

        void Start()
        {
            // Ensure the interact canvas is initially hidden
            interactCanvas.gameObject.SetActive(false);

            // Ensure the interact text is initially disabled
            interactText.SetActive(false);

            // Ensure the dialogue canvas is initially hidden
            dialogueCanvas.gameObject.SetActive(false);

            // Ensure the player object is initially hidden
            playerObject.gameObject.SetActive(false);

            // Ensure the puzzle canvas is initially hidden
            if (puzzleCanvas != null)
            {
                puzzleCanvas.SetActive(false);
            }

            // Subscribe to the dialogue end event
            if (dialogueManager != null)
            {
                dialogueManager.onDialogueEnd.AddListener(OnDialogueEnd);
            }

            // Ensure the ScriptInteract object is initially inactive
         
        }

        void Update()
        {
            // Check if player is in range and interaction key is pressed
            if (playerInRange && !isInteracting && Input.GetKeyDown(interactKey))
            {
                // Start the interaction if not already interacting
                StartInteraction();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Player is in range for interaction
                playerInRange = true;

                // Show interaction prompt
                ShowInteractText(true);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Player is no longer in range
                playerInRange = false;

                // Hide interaction prompt
                ShowInteractText(false);
            }
        }

        void StartInteraction()
        {
            isInteracting = true; // Interaction has started

            // Show the interact canvas
            interactCanvas.gameObject.SetActive(true);

            // Start playing animation
            StartCoroutine(PlayAnimation());
        }

        IEnumerator PlayAnimation()
        {
            // Loop through animation frames
            foreach (Sprite frame in animationFrames)
            {
                animationImage.sprite = frame;
                yield return new WaitForSeconds(frameDuration);
            }

            // Animation completed, disable interact canvas
            interactCanvas.gameObject.SetActive(false);

            // Disable the BoxCollider2D on the mypcs object
            if (mypcs != null)
            {
                BoxCollider2D collider = mypcs.GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.enabled = false;

                }
            }

            // Show the player object during dialogue
            if (playerObject != null)
            {
                playerObject.SetActive(true);
            }

            // Show the dialogue canvas
            dialogueCanvas.gameObject.SetActive(true);

            // Notify DialogueManager (DialogueZ) to start the dialogue
            if (dialogueManager != null && !string.IsNullOrEmpty(dialogueIdFirst))
            {
                DialogueZ.SetDatabase(dialogueManager.db);

                DialogueZElement element;
                if (DialogueZ.TryGetDialogue_Ids(dialogueIdFirst, out element))
                {
                    DialogueZ.Init(element, dialogueManager.db);
                    currentDialogueId = dialogueIdFirst; // Set the current dialogue ID
                }
                else
                {
                    Debug.LogError("Dialogue element with ID " + dialogueIdFirst + " not found.");
                }
            }
        }

        void OnDialogueEnd()
        {
            Debug.Log("OnDialogueEnd called for dialogue ID: " + currentDialogueId);

            // Check if the current dialogue is the last one
            if (currentDialogueId == dialogueIdLast)
            {
                Debug.Log("Last dialogue ended, hiding player object.");

                // Hide the player object
                if (playerObject != null)
                {
                    playerObject.SetActive(false);
                }

                // Activate the ScriptInteract object
             
            }
            else
            {
                Debug.Log("Dialogue ended but not the last one, keeping player object active.");
            }

            // Dialogue has ended, hide dialogue canvas
            dialogueCanvas.gameObject.SetActive(false);

            // Reset interaction flag
            isInteracting = false;
        }

        void ShowInteractText(bool show)
        {
            if (interactText != null)
            {
                interactText.SetActive(show);
            }
        }
    }
}
