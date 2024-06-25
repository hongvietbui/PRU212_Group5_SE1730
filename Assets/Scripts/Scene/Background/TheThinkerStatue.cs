using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheThinkerStatue : MonoBehaviour
{
    public GameObject canvas;
    public GameObject dialoguePanel;
    public TMP_Text dialogueTextTMP;
    private bool isPlayerNear = false;
    private PlayerController playerController;
    public TypeWriterEffect typeWriterEffect;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
        canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Check if the dialogue is shown and player press E to hide it
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            HideDialogue();
            return;
        }

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
            canvas.SetActive(true);
            playerController = collision.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            if(canvas!=null)
                canvas.SetActive(false);
            dialoguePanel.SetActive(false);
            canvas.SetActive(false);
        }
    }

    void ShowDialogue() {
        canvas.SetActive(true);
        dialoguePanel.SetActive(true);

        if(playerController != null)
            playerController.isDialogueActive = true;

        typeWriterEffect.StartTypewriterEffect("The Thinker is a bronze sculpture by Auguste Rodin, usually placed on a stone pedestal. The work shows...");
        //dialogueTextTMP.text = "The Thinker is a bronze sculpture by Auguste Rodin, usually placed on a stone pedestal. The work shows...";
    }

    public void HideDialogue()
    {
        canvas.SetActive(false);
        dialoguePanel.SetActive(false);

        if (playerController != null)
            playerController.isDialogueActive = false;
    }
}
