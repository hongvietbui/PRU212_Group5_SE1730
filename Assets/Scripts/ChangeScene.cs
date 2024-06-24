using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneName;
    public GameObject player; // Reference to the player object

    private void Start()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is not set. Please set the scene name in the inspector.");
        }

        if (player == null)
        {
            Debug.LogError("Player object is not set. Please set the player object in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.gameObject == player)
        {
            Debug.Log("Player detected. Attempting to load scene: " + sceneName);

            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                Debug.Log("Scene " + sceneName + " found. Loading now...");
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Scene " + sceneName + " cannot be found. Please check the scene name and ensure it is added to the Build Settings.");
            }
        }
        else
        {
            Debug.Log("Non-player object detected: " + other.name);
        }
    }
}
