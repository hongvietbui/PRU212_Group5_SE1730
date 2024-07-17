using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cutsceneStair : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public string sceneName;

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

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);


    }
  

}
