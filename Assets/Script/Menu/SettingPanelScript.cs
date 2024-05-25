using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelScript : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject volumeValueText;
    public GameObject volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        //check if setting panel is null or not
        if (settingPanel == null) {
            Debug.LogError("Setting panel is not assigned in the Inspector");
            return;
        }

        //check if volume value text is null or not
        if (volumeValueText == null) { 
            Debug.LogError("Volume value text is not assigned in the Inspector");
            return;
        }

        //check if volume slider is null or not
        if (volumeSlider == null)
        {
            Debug.LogError("Volume slider is not assigned in the Inspector");
            return;
        }

        settingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Change the volume value text based on the volume slider value
        if(volumeValueText != null && volumeSlider != null)
            volumeValueText.GetComponent<Text>().text = (volumeSlider.GetComponent<Slider>().value*100).ToString("000.")+"%";
    }

    public void ToggleSettingPanel()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void SetActive(bool value) {
        settingPanel.SetActive(value);
    }
}
