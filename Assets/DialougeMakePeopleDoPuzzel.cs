using System;
using UnityEngine;
using UnityEngine.Events;

public class DialougeMakePeopleDoPuzzel : MonoBehaviour
{
    // Event triggered when the player collides with the object
    public UnityEvent OnPlayerHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when another collider enters the trigger collider attached to this object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Invoke the OnPlayerHit event when the player collides with this object
            OnPlayerHit.Invoke();
        }
    }
}
