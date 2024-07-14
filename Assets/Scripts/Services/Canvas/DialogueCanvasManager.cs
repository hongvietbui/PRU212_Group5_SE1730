using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvasManager : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public GameObject dialoguePrefab;
    private GameObject currentDialogue;

    public void displayDialogue()
    {
        // Ensure dialogueCanvas and dialoguePrefab are assigned
        if (dialogueCanvas == null || dialoguePrefab == null)
        {
            Debug.LogError("Dialogue Canvas or Prefab is not assigned!");
            return;
        }

        //check if the currentDialogue is null or not
        if(currentDialogue != null)
        {
            Destroy(currentDialogue);
        }

        // Check if Dialogue_Dan (Fantasy) already exists
        Transform existingDialogue = dialogueCanvas.transform.Find("Dialogue_Dan (Fantasy)");
        // Destroy the existing Dialogue_Dan (Fantasy) if it exists
        if (existingDialogue != null)
        {
            Destroy(existingDialogue.gameObject);
        }
        // Instantiate the new Dialogue_Dan (Fantasy) as a child of DialogueCanvas
        currentDialogue = Instantiate(dialoguePrefab, dialogueCanvas.transform);
        currentDialogue.name = "Dialogue_Dan (Fantasy)";
        // Activate the DialogueCanvas
        currentDialogue.gameObject.SetActive(true);
        dialogueCanvas.gameObject.SetActive(true);
    }

    public void hideDialogue()
    {
        // Ensure dialogueCanvas and dialoguePrefab are assigned
        if (dialogueCanvas == null || dialoguePrefab == null)
        {
            Debug.LogError("Dialogue Canvas or Prefab is not assigned!");
            return;
        }
        // Check if Dialogue_Dan (Fantasy) already exists
        Transform existingDialogue = dialogueCanvas.transform.Find("Dialogue_Dan (Fantasy)");
        // Destroy the existing Dialogue_Dan (Fantasy) if it exists
        if (existingDialogue != null)
        {
            Destroy(existingDialogue.gameObject);
        }
        dialogueCanvas.gameObject.SetActive(false);
    }
}
