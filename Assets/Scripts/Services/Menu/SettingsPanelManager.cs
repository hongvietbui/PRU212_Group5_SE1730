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
    public TMPro.TextMeshProUGUI MainMenuText;

    //Key mapping configuration

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = AudioManager.Instance.musicSource.volume;
    }

    //set volume
    public void SetVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }

    //show settings panel
    public void ShowSettings()
    {
        //Hide main menu text
        MainMenuText.gameObject.SetActive(false);
        settingPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    //hide settings panel
    public void HideSettings()
    {
        //Show MainMenuText
        MainMenuText.gameObject.SetActive(true);
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
