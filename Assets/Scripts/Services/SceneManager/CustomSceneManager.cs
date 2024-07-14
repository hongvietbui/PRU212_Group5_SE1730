using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static void changeScene(string sceneName) {
        //Load to other scene
        SceneManager.LoadScene(sceneName);
    }
}
