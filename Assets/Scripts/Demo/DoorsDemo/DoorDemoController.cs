using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private float doorState;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorState = 0;
        animator.SetFloat("DoorState", doorState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            doorState = 2; 
            animator.SetFloat("DoorState", doorState);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            doorState = 1; 
            animator.SetFloat("DoorState", doorState);
        }
        else if (Input.GetKeyDown(KeyCode.I)) 
        {
            doorState = 3; 
            animator.SetFloat("DoorState", doorState);
        }
        else if (Input.GetKeyDown(KeyCode.L)) 
        {
            doorState = 0;
            animator.SetFloat("DoorState", doorState);
        }
    }
}
