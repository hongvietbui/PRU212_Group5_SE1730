using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //private float volume = 1f;
    private Dictionary<string, KeyCode> keyMappings = new Dictionary<string, KeyCode>();
    //public float Volume
    //{
    //    get { return volume; }
    //    set
    //    {
    //        volume = value;
    //        AudioListener.volume = volume;
    //    }
    //}

    public Dictionary<string, KeyCode> KeyMappings
    {
        get { return keyMappings; }
        set { keyMappings = value; }
    }

    public override void Awake()
    {
        base.Awake();
        //Load key mapping data from player prefs
        LoadKeyMapping();
        //check if the key mapping is null or not
        if (keyMappings == null || keyMappings.Count == 0)
        {
            keyMappings = new Dictionary<string, KeyCode>
            {
                //set default key mapping
                { "Left", KeyCode.A },
                { "Right", KeyCode.D },
                { "Up", KeyCode.W},
                { "Down", KeyCode.S},
                { "Jump", KeyCode.Space },
                { "Interact", KeyCode.E },
                { "Inventory", KeyCode.I },
                { "Pause", KeyCode.Escape }
            };
        }
    }

    public void SaveKeyMappingToPlayerPrefs() {
        foreach(var mapping in keyMappings)
        {
            PlayerPrefs.SetString(mapping.Key, mapping.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void LoadKeyMapping() {
        List<string> KeysToUpdate = new List<string>();
        
        foreach(var mapping in keyMappings)
        {
            if(PlayerPrefs.HasKey(mapping.Key))
            {
                //keyMappings[mapping.Key] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(mapping.Key));
                KeysToUpdate.Add(mapping.Key);
            }
        }

        foreach(var key in KeysToUpdate)
        {
            keyMappings[key] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key));
        }
    }

   
}
