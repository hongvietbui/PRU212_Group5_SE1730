using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : Singleton<PauseMenuManager>
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
        pauseMenuCanvas.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        isPaused = !pauseMenuCanvas.activeSelf;
        pauseMenuCanvas.SetActive(isPaused);

        if (playerController != null)
        {
            playerController.SetPauseState(isPaused);
        }

        Time.timeScale = isPaused ? 0 : 1;
    }
}
