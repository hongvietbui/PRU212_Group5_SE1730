using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtonScript : MonoBehaviour
{
    public Button settingButton;
    public GameObject settingPanel;
    // Start is called before the first frame update
    void Start()
    {
        //check if setting panel is null or not
        if(settingPanel == null)
        {
            Debug.LogError("Setting Panel is null");
            return;
        }

        //check if setting button is null or not
        if(settingButton == null)
        {
            Debug.LogError("Setting Button is null");
            return;
        }


        settingPanel.SetActive(false);
        settingButton.onClick.AddListener(() =>
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
