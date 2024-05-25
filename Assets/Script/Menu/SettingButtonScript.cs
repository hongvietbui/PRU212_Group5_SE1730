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
