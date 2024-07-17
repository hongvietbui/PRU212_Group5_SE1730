using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanhBetaAudioManager : MonoBehaviour
{
    public List<AudioClip> backgroundMusics;
    public List<AudioClip> effectMusics;
    public string soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SetBackgroundMusicList(backgroundMusics);
        AudioManager.Instance.SetSoundEffectList(effectMusics);
        AudioManager.Instance.PlayMusic(soundToPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
