using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float volume = 1f;
    public float Volume
    {
        get { return volume; }
        set
        {
            volume = value;
            AudioListener.volume = volume;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
