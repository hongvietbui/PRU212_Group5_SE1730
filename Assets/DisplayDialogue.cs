using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisplayDialogue : MonoBehaviour
{
	public UnityEvent OnPlayerHit;
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
