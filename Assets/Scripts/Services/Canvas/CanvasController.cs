using narrenschlag.dialoguez;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.E;
    public List<DialogueZBase> dialogueList;
    public Canvas dialogueCanvas;
    private int state = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
        }
    }

    private void ToggleCanvas()
    {
        //Check if witch canvas is enable or not
        if(this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
            displayDialogue(dialogueList);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void ActiveCanvas() {
        this.gameObject.SetActive(true);
    }

    public void displayDialogue(List<DialogueZBase> dialogueList)
    {
        //Check if the state is valid or not
        if (state + 1 > dialogueList.Count || dialogueList.Count == 0 || dialogueList == null)
        {
            state = 0;
            dialogueCanvas.gameObject.SetActive(false);
            return;
        }

        DialogueZ.SetDatabase(dialogueList[state]);
        dialogueCanvas.gameObject.SetActive(true);
        state++;
    }
}
