using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02Management : MonoBehaviour
{
    public List<AudioClip> backgroundMusicList;
    public List<AudioClip> effectList;

    public string backgroundMusicToPlayName;
    // Start is called before the first frame update
    void Start()
    {
        //Load background and effect list
        AudioManager.Instance.SetBackgroundMusicList(backgroundMusicList);
        AudioManager.Instance.SetSoundEffectList(effectList);
        //Play background music
        AudioManager.Instance.PlayMusic(backgroundMusicToPlayName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
