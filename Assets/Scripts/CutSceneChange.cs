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


    }

  
}
