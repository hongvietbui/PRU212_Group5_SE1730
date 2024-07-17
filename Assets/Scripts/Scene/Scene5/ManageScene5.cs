using System.Collections.Generic;
using UnityEngine;

public class ManageScene5 : MonoBehaviour
{
	public List<AudioClip> backgroundMusicList;
	public List<AudioClip> effectList;
	public string backgroundMusicToPlayName;

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
}
