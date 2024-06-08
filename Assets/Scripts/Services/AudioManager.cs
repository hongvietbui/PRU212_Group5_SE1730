using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public List<AudioClip> soundEffects;

    private Dictionary<string, AudioClip> soundEffectDict;

    public override void Awake()
    {
        base.Awake();
        //Check if the Instance is singleton Instance or not
        if (this == Instance)
        {
            InitializeSoundEffects();
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

    public void PlayMusic() {
        if(musicSource.isPlaying) return;
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
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
}
