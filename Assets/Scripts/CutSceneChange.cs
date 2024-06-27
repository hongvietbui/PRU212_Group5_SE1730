using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update

    void Start()
    {
        // Ensure the video player is assigned
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Play the video on start
        videoPlayer.Play();

        // Optional: Add a callback for when the video finishes
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Transition to the gameplay scene
        // For example, load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
