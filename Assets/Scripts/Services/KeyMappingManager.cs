using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyMappingManager : MonoBehaviour
{
    public TMP_InputField leftKeyInput;
    public TMP_InputField rightKeyInput;
    public TMP_InputField upKeyInput;
    public TMP_InputField downKeyInput;
    public TMP_InputField jumpKeyInput;
    public TMP_InputField interactKeyInput;
    public TMP_InputField inventoryKeyInput;
    public TMP_InputField pauseKeyInput;
    public Button applyButton;
    public Button cancelButton;

    private string currentKey;
    // Start is called before the first frame update
    void Start()
    {
        UpdateInputFields();

        leftKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Left"); });
        rightKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Right"); });
        upKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Up"); });
        downKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Down"); });
        jumpKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Jump"); });
        interactKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Interact"); });
        inventoryKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Inventory"); });
        pauseKeyInput.onValueChanged.AddListener(delegate { ChangeKeyMapping("Pause"); });

        applyButton.onClick.AddListener(delegate { HandleApplyKey(); });
        cancelButton.onClick.AddListener(delegate { HandleCancelKey(); });
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the user press any key
        if (!string.IsNullOrEmpty(currentKey))
        {
            //Access all the key code in the KeyCode enum
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                //Check if the user press any key
                if (Input.GetKeyDown(keyCode))
                {
                    //Check if the user press the mouse button or return key
                    if (keyCode == KeyCode.Mouse0 || keyCode == KeyCode.Mouse1 || keyCode == KeyCode.Mouse2 || keyCode == KeyCode.Return) {
                        continue;
                    }
                    GameManager.Instance.KeyMappings[currentKey] = keyCode;
                    UpdateInputField(currentKey, keyCode);
                    currentKey = null;
                    break;
                }
            }
        }
    }

    public void ChangeKeyMapping(string key)
    {
        currentKey = key;
    }

    void ValidateAndChangeKeyMapping(string key) {
        TMP_InputField inputField = GetInputFieldByKey(key);
        if (inputField != null) {
            string inputKey = inputField.text.ToUpper();
            if (inputKey.Length > 1)
            {
                inputField.text = inputKey[inputKey.Length-1].ToString();
                inputKey = inputField.text;
            }

            if (!IsDuplicatedKey(inputKey))
            {
                currentKey = key;
                inputField.text = inputKey;
            } else
            {
                inputField.text = string.Empty;
            }
        }
    }

    TMP_InputField GetInputFieldByKey(string key)
    {
        switch (key)
        {
            case "Left":
                return leftKeyInput;
            case "Right":
                return rightKeyInput;
            case "Up":
                return upKeyInput;
            case "Down":
                return downKeyInput;
            case "Jump":
                return jumpKeyInput;
            case "Interact":
                return interactKeyInput;
            case "Inventory":
                return inventoryKeyInput;
            case "Pause":
                return pauseKeyInput;
            default:
                return null;
        }
    }

    void UpdateInputFields() {
        leftKeyInput.text = GameManager.Instance.KeyMappings["Left"].ToString();
        rightKeyInput.text = GameManager.Instance.KeyMappings["Right"].ToString();
        upKeyInput.text = GameManager.Instance.KeyMappings["Up"].ToString();
        downKeyInput.text = GameManager.Instance.KeyMappings["Down"].ToString();
        jumpKeyInput.text = GameManager.Instance.KeyMappings["Jump"].ToString();
        interactKeyInput.text = GameManager.Instance.KeyMappings["Interact"].ToString();
        inventoryKeyInput.text = GameManager.Instance.KeyMappings["Inventory"].ToString();
        pauseKeyInput.text = GameManager.Instance.KeyMappings["Pause"].ToString();
    }

    void UpdateInputField(string key, KeyCode keyCode)
    {
        switch (key) {
            case "Left":
                leftKeyInput.text = keyCode.ToString();
                break;
            case "Right":
                rightKeyInput.text = keyCode.ToString();
                break;
            case "Up":
                upKeyInput.text = keyCode.ToString();
                break;
            case "Down":
                downKeyInput.text = keyCode.ToString();
                break;
            case "Jump":
                jumpKeyInput.text = keyCode.ToString();
                break;
            case "Interact":
                interactKeyInput.text = keyCode.ToString();
                break;
            case "Inventory":
                inventoryKeyInput.text = keyCode.ToString();
                break;
            case "Pause":
                pauseKeyInput.text = keyCode.ToString();
                break;
        }
    }

    bool IsDuplicatedKey(string keyString) {
        KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString);
        return IsDuplicatedKey(keyCode);
    }

    bool IsDuplicatedKey(KeyCode keyCode)
    {
        foreach (var mapping in GameManager.Instance.KeyMappings)
        {
            if (mapping.Value == keyCode)
            {
                return true;
            }
        }
        return false;
    }

    void HandleApplyKey() {
        GameManager.Instance.SaveKeyMappingToPlayerPrefs();
    }

    void HandleCancelKey() {
        GameManager.Instance.LoadKeyMapping();
        UpdateInputFields();
    }
}
