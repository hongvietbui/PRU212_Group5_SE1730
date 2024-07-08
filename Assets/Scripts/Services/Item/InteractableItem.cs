using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public InteractableEvent[] interactableEvents;

    private bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            TriggerEvents();
        }
    }

    void TriggerEvents() {
        //invoke every event
        foreach (InteractableEvent interactableEvent in interactableEvents)
        {
            Debug.Log("Event: "+ interactableEvent.eventName);
            interactableEvent.unityEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
