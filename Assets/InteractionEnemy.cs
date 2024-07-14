using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractionEnemy : MonoBehaviour
{
    private bool playerInRange = false;
    public UnityEvent OnGameStart;

    void Start()
    {
        OnGameStart.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range for interaction.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player out of range for interaction.");
        }
    }

    private void Interact()
    {
        SceneManager.LoadScene("CutSceneEnd");
    }
}
