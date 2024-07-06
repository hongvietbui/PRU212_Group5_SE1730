using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class computerInteract : MonoBehaviour
{
    public Canvas interactCanvas;           // Reference to the Canvas to show/hide
    public GameObject interactTextObject;   // GameObject containing Text component for interaction prompt
    public float fadeDuration = 1.0f;       // Duration for fading in and out
    public KeyCode interactKey = KeyCode.E; // Key to interact (E key by default)

    private bool playerInRange = false;     // Flag to track if player is in range for interaction
    private bool interacted = false;        // Flag to track if interaction has occurred
    private CanvasGroup canvasGroup;        // Reference to the CanvasGroup for fading

    private Text interactText;              // Text component reference

    void Start()
    {
        // Get the CanvasGroup component for fading
        canvasGroup = interactCanvas.GetComponent<CanvasGroup>();

        // Ensure the interact canvas is initially hidden
        interactCanvas.gameObject.SetActive(false);

        // Get the Text component from interactTextObject GameObject
        interactText = interactTextObject.GetComponent<Text>();

        // Ensure the interaction prompt is initially hidden
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if player is in range and interaction key is pressed
        if (playerInRange && !interacted && Input.GetKeyDown(interactKey))
        {
            // Display interact canvas
            ShowInteractCanvas();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is in range for interaction
            playerInRange = true;

            // Show interaction prompt
            if (interactText != null)
            {
                interactText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player is no longer in range
            playerInRange = false;

            // Hide interaction prompt
            if (interactText != null)
            {
                interactText.gameObject.SetActive(false);
            }
        }
    }

    void ShowInteractCanvas()
    {
        interacted = true; // Interaction has occurred

        // Show the interact canvas
        interactCanvas.gameObject.SetActive(true);

        // Start fading in the canvas
        StartCoroutine(FadeCanvas(canvasGroup, 0f, 1f, fadeDuration));

        // Example: Start fading out after 3 seconds
        Invoke("FadeOutInteractCanvas", 3f);
    }

    IEnumerator FadeCanvas(CanvasGroup canvasGroup, float startAlpha, float targetAlpha, float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float normalizedTime = (Time.time - startTime) / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha; // Ensure alpha reaches exactly targetAlpha
    }

    void FadeOutInteractCanvas()
    {
        StartCoroutine(FadeCanvas(canvasGroup, 1f, 0f, fadeDuration));

        // Disable interaction prompt text
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }

        // Prevent further interactions
        interacted = true;
    }
}
