using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionGuide : MonoBehaviour
{
    public GameObject instructionCanvas; // Reference to the Instruction Canvas

    void Start()
    {
        // Initially hide the instruction guide
        instructionCanvas.SetActive(true);
    }

    public void ShowInstructions()
    {
        instructionCanvas.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            instructionCanvas.SetActive(true);
        }
    }
    public void HideInstructions()
    {
        instructionCanvas.SetActive(false);
    }
}
