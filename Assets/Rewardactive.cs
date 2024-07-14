using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewardactive : MonoBehaviour
{
    public Canvas targetCanvas;
    private bool playerInCollider = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has a specific tag if needed, e.g., "Player"
        if (other.CompareTag("Player"))
        {
            // Set the flag to true when the player enters the collider
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other object has a specific tag if needed, e.g., "Player"
        if (other.CompareTag("Player"))
        {
            // Set the flag to false when the player exits the collider
            playerInCollider = false;
        }
    }

    private void Update()
    {
        // Check if the player is in the collider and presses the "E" key
        if (playerInCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Activate the Canvas
            targetCanvas.gameObject.SetActive(true);
        }
    }
}
