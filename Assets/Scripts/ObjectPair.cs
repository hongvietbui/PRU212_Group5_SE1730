using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPair : MonoBehaviour
{
    public GameObject pairedObject;  // The object in the second hallway
    private Vector3 initialOffset;

    void Start()
    {
        // Calculate the initial offset between the paired objects
        if (pairedObject != null)
        {
            initialOffset = pairedObject.transform.position - transform.position;
        }
    }

    void Update()
    {
        // Sync position with the paired object, with inverted y-coordinate
        if (pairedObject != null)
        {
            Vector3 newPosition = transform.position + initialOffset;
            newPosition.y = -transform.position.y;
            pairedObject.transform.position = newPosition;
        }
    }
}