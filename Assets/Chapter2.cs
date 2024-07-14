using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chapter2 : MonoBehaviour
{
    public UnityEvent Dialouge;

    // Start is called before the first frame update
    void Start()
    {
        Dialouge.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
