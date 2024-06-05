using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SettingsManager settingsManager; 
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
        Debug.Log("Settings opened");
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
