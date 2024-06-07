using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseMenu;

    public void ShowGameOver(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }

    public void ShowPauseMeny(bool isShow)
    {
        if(pauseMenu)
        {
            pauseMenu.SetActive(isShow);
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
