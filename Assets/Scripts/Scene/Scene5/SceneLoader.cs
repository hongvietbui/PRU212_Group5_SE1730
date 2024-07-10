using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        PuzzleState.savedPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        SceneManager.LoadScene("PhotoPuzzle");
    }
}
