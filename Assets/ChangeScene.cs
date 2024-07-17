using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Change "Player" to the tag of the object that triggers the change
        {

            SceneManager.LoadScene(sceneName);
        }
    }
}
