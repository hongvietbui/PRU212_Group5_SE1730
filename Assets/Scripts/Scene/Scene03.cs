using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneManagement : MonoBehaviour
{
    public List<AudioClip> backgroundMusicList;
    public List<AudioClip> effectList;
    public string backgroundMusicName;
    // Start is called before the first frame update
    void Start()
    {
        //Reload background music list
        AudioManager.Instance.SetBackgroundMusicList(backgroundMusicList);
        //Reload effect list
        AudioManager.Instance.SetSoundEffectList(effectList);
        //Play background music
        AudioManager.Instance.PlayMusic(backgroundMusicName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
