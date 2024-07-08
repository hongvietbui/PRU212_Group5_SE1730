using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        InventoryControl();
    }

    private void InventoryControl()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //if Game is Paused, press Escape, Resume the Game
            if(InventoryManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();//if Game is Reusme, Press Escape, Pasue the Game 
            }

        }
    }

    private void Resume()
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Real time is 1.0f
        InventoryManager.instance.isPaused = false;
    }

    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//STOP THE TIME
        InventoryManager.instance.isPaused = true;
    }


}
