using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public List<AudioClip> backgroundMusicList;
    public List<AudioClip> effectList;
    public string backgroundMusicToPlayName;

    private bool isTheThinkerPuzzleDone = false;

    // Start is called before the first frame update
    void Start()
    {
        //Reload background music list
        AudioManager.Instance.SetBackgroundMusicList(backgroundMusicList);
        //Reload effect list
        AudioManager.Instance.SetSoundEffectList(effectList);
        //Play background music
        AudioManager.Instance.PlayMusic(backgroundMusicToPlayName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeTheThinkerPuzzleStatus(bool status) {
        isTheThinkerPuzzleDone = status;
    }
}
