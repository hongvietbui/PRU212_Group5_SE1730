using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputManager : Singleton<InputManager>
{
    public UserInputActions inputActions;
    public TMP_Text bindingDisplayNameText;

    public void Awake()
    {
        inputActions = new UserInputActions();
        inputActions.Player.Enable();
    }

    private void OnEnable()
    {
        inputActions.Player.OpenSettingsPause.performed += OnPauseMenu;
    }

    private void OnDisable()
    {
        inputActions.Player.OpenSettingsPause.performed -= OnPauseMenu;
    }

    private void OnPauseMenu(InputAction.CallbackContext context)
    {
        PauseMenuManager.Instance.TogglePauseMenu();
    }
}
