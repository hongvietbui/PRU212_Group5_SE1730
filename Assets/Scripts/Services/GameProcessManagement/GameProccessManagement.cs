using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProccessManagement : Singleton<GameProccessManagement>
{
    // List of scenes to manage
    [SerializeField]
    private static List<string> scenesToManage;

    // Current scene index
    private static int currentSceneIndex = 0;

    // Function to set scenes to manage
    public static void SetScenesToManage(List<string> scenes)
    {
        scenesToManage = scenes;
        currentSceneIndex = 0;
    }

    // Function to load the next scene in the list
    public void LoadNextScene()
    {
        if (currentSceneIndex < scenesToManage.Count)
        {
            SceneManager.LoadScene(scenesToManage[currentSceneIndex]);
            currentSceneIndex++;
        }
        else
        {
            Debug.Log("All scenes have been loaded.");
        }
    }

    // Function to restart the game from the first scene
    public void RestartGame()
    {
        currentSceneIndex = 0;
        if (scenesToManage.Count > 0)
        {
            SceneManager.LoadScene(scenesToManage[currentSceneIndex]);
        }
        else
        {
            Debug.LogError("No scenes to manage.");
        }
    }
}
