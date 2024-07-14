using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject questionPanel;
    private bool isInRange = false;
    private QuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel.SetActive(false);
            quizManager.StartQuiz();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QuestionTrigger"))
        {
            dialoguePanel.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("QuestionTrigger")&&(isInRange == true))
        {
            dialoguePanel.SetActive(false);
            questionPanel.SetActive(false);
            isInRange = false;
        }
    }
}
