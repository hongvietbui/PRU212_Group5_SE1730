using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void ShowObject();
    public ShowObject onShowObject;

    public delegate void HideObject();
    public HideObject onHideObject;

    public void Show() {
        if(onShowObject != null)
        {
            onShowObject();
        }
    }

    public void Hide()
    {
        if(onHideObject != null)
        {
            onHideObject();
        }
    }   
}
