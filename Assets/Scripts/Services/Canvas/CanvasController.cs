using narrenschlag.dialoguez;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.E;
    public List<UnityEvent> eventAfterClosedCanvas;

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

            foreach(var e in eventAfterClosedCanvas)
            {
                e.Invoke();
            }
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void ActiveCanvas() {
        this.gameObject.SetActive(true);
    }
}
