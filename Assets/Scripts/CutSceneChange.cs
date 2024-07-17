using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject gameOverCanvas;  // Reference to the Game Over canvas
    public string sceneName;
    void Start()
    {
        // Ensure the video player is assigned
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Ensure the game over canvas is initially hidden
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        // Play the video on start
        videoPlayer.Play();

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Display the Game Over canvas when the video ends
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    // Method to be called by the button in the Game Over canvas
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
