using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SettingsPanelManager settingsManager;

    // Start is called before the first frame update
    void Start()
    {
        //Play background music
        AudioManager.Instance.PlayMusic();
    }
    //Play new game
    public void PlayNewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    //open load game menu
    public void LoadGamePanel()
    {
        //Open load game panel

    }
    
    //Open settings panel
    public void OpenSettings()
    {
        //Open setting panel
        settingsManager.ShowSettings();
    }

    //quit game
    public void QuitGame()
    {
        //check if the game is in editor mode or not
        if(Application.isEditor || Application.isPlaying)
        {
            //stop playing in editor mode
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            //quit the game
            Application.Quit();
        }
    }
}
