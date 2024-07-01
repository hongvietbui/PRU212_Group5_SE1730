using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        //foreach (GameObject canvas in targetCanvasList)
        //{
        //    if(canvas != null)
        //    {
        //        canvas.SetActive(false);
        //    }
        //    else
        //    {
        //        Debug.LogError("Canvas is null in CanvasController: " + this.gameObject.name);
        //    }
        //}
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
