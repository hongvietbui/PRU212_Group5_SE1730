using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("Audio Clips")]
    public List<AudioClip> backgroundMusics;
    public List<AudioClip> soundEffects;

    private Dictionary<string, AudioClip> soundEffectDict;
    private Dictionary<string, AudioClip> backgroundMusicDict;

    public override void Awake()
    {
        base.Awake();
        //Check if the Instance is singleton Instance or not
        if (this == Instance)
        {
            InitializeSoundEffects();
            InitializeBackgroundMusics();
        }
    }

    private void InitializeSoundEffects()
    {
        soundEffectDict = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in soundEffects)
        {
            soundEffectDict.Add(clip.name, clip);
        }
    }

    private void InitializeBackgroundMusics()
    {
        backgroundMusicDict = new Dictionary<string, AudioClip>();
        foreach (AudioClip backgroundMusic in backgroundMusics) {
            backgroundMusicDict.Add(backgroundMusic.name, backgroundMusic);
        }
    }

    public void PlayMusic(string musicName) {
        if (backgroundMusicDict.ContainsKey(musicName))
        {
            musicSource.clip = backgroundMusicDict[musicName];
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music not found: " + musicName);
        }
    }

    public void StopMusic() {
        musicSource.Stop();
    }

    public void PlaySoundEffect(string effectName) {
        //Check if the sound effect exists in the dictionary
        if (soundEffectDict.ContainsKey(effectName))
        {
            effectSource.PlayOneShot(soundEffectDict[effectName]);
        }
        else
        {
            Debug.LogError("Sound effect with name " + effectName + " not found in the dictionary");
        }
    }

    public void StopSoundEffect()
    {
        effectSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSoundEffectVolume(float volume)
    {
        effectSource.volume = volume;
    }

    public void SetBackgroundMusicList(List<AudioClip> backgroundMusicList)
    {
        backgroundMusics = backgroundMusicList;
        InitializeBackgroundMusics();
    }

    public void SetSoundEffectList(List<AudioClip> soundEffectList)
    {
        soundEffects = soundEffectList;
        InitializeSoundEffects();
    }
}
