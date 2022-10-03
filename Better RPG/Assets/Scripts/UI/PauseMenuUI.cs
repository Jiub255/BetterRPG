using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static event Action OnEscapePressed;

    public GameObject MenuPanel;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction openPauseMenu;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        openPauseMenu = playerControls.Player.OpenPauseMenu;
        openPauseMenu.Enable();
    }

    private void OnDisable()
    {
        openPauseMenu.Disable();
    }



    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        if (openPauseMenu.WasPressedThisFrame())
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        OnEscapePressed?.Invoke();
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void ToggleOptionsMenu()
    {
        //MenuPanel.SetActive(false);
        //OptionsPanel.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        // exit save here?
        SceneManager.LoadScene("MainMenu");
    }
}