using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
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
    
        public GameObject puzzleCanvas;     // Reference to the puzzle UI canvas
        public AudioClip interactionSound;  // Sound to play on interaction start and end
        public AudioClip rewardSound;       // Sound to play when the reward canvas is set active

        private bool playerInRange = false; // Flag to track if player is in range for interaction
        private bool isInteracting = false; // Flag to track if interaction is ongoing
        private string currentDialogueId;   // Tracks the current dialogue ID
        private AudioSource audioSource;    // Reference to the AudioSource component
        public Canvas InstructionDialouge;
        // Define events for game start and after animation
        public UnityEvent OnGameStart;
        public UnityEvent OnAfterAnimation;

        void Start()
        {
           // Ensure the interact canvas is initially hidden
            interactCanvas.gameObject.SetActive(false);

          //  Ensure the interact text is initially disabled
            interactText.SetActive(false);

         //   Ensure the dialogue canvas is initially hidden
            dialogueCanvas.gameObject.SetActive(false);

          //  Ensure the player object is initially hidden
            playerObject.gameObject.SetActive(false);

          //  Ensure the puzzle canvas is initially hidden
            if (puzzleCanvas != null)
            {
                puzzleCanvas.SetActive(false);
            }

          //  Get the AudioSource component
            audioSource = GetComponent<AudioSource>();

          //  Subscribe to the dialogue end event
           InstructionDialouge.gameObject.SetActive(false);

           //  Trigger the game start event
            OnGameStart.Invoke();
           InstructionDialouge.gameObject.SetActive(true);
         //   Start the first dialogue at the beginning of the project

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

            // Play interaction sound
            if (interactionSound != null)
            {
                audioSource.PlayOneShot(interactionSound);
            }

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

            // Trigger the after animation event
            OnAfterAnimation.Invoke();

            // Notify DialogueManager (DialogueZ) to start the second dialogue

        }

      

        void ShowInteractText(bool show)
        {
            if (interactText != null)
            {
                interactText.SetActive(show);
            }
        }

        public void ShowPuzzleCanvas()
        {
            if (puzzleCanvas != null)
            {
                puzzleCanvas.SetActive(true);

                // Play reward sound
                if (rewardSound != null)
                {
                    audioSource.PlayOneShot(rewardSound);
                }
            }
        }
    }
}
