using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelManager : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeValue;
    public GameObject settingPanel;
    public GameObject mainMenuPanel;
    //Key mapping configuration
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = GameManager.Instance.Volume;


    }

    //set volume
    public void SetVolume(float volume)
    {
        GameManager.Instance.Volume = volume;
    }

    //show settings panel
    public void ShowSettings()
    {
        settingPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    //hide settings panel
    public void HideSettings()
    {
        settingPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Change volume text depends on slider value
        volumeValue.text = (int)(volumeSlider.value * 100) + "%";
    }
}
