using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    public Button settingButton;
    // Start is called before the first frame update
    void Start()
    {
        settingButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() { 
        Debug.Log("Setting Button Clicked");
        //Change setting panel to active
        GameObject.Find("SettingPanel").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
