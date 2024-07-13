using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Scene02 : MonoBehaviour
{
    public UnityEvent startEvent;
    public GameObject DialougeCanvas;

    // Start is called before the first frame update
    void Start()
    {
      
        startEvent.Invoke();
        DialougeCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
