using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscapeMenuUI : MonoBehaviour
{
    public GameObject EscapeMenuPanel;
    public GameObject HUDPanel;

    // for pausing game
    public static event Action<bool> OnTogglePause;

    // new input system stuff
    private InputAction openEscapeMenu;
    private InputAction closeEscapeMenu;
    InputAction closeAllMenus;

    private void OnEnable()
    {
        openEscapeMenu = InputManager.inputActions.Player.OpenPauseMenu;
        openEscapeMenu.Enable();
        openEscapeMenu.performed += OpenEscapeMenu;

        closeEscapeMenu = InputManager.inputActions.UI.ClosePauseMenu;
        closeEscapeMenu.Enable();
        closeEscapeMenu.performed += CloseEscapeMenu;

        closeAllMenus = InputManager.inputActions.UI.CloseAllMenus;
        closeAllMenus.Enable();
        closeAllMenus.performed += CloseEscapeMenu;
    
       // InputManager.actionMapChange += ChangeActionMap;
    }

    private void OnDisable()
    {
        openEscapeMenu.Disable();
        openEscapeMenu.performed -= OpenEscapeMenu;

        closeEscapeMenu.Disable();
        closeEscapeMenu.performed -= CloseEscapeMenu;

        closeAllMenus.Disable();
        closeAllMenus.performed -= CloseEscapeMenu;

        //  InputManager.actionMapChange -= ChangeActionMap;
    }

    void OpenEscapeMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Open Escape Menu");

        EscapeMenuPanel.SetActive(true);
        HUDPanel.SetActive(false);
        OnTogglePause?.Invoke(true);
        InputManager.ToggleActionMap(InputManager.inputActions.UI);
    }

    void CloseEscapeMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Close Escape Menu");
        
        EscapeMenuPanel.SetActive(false);
        HUDPanel.SetActive(true);
        OnTogglePause?.Invoke(false);
        InputManager.ToggleActionMap(InputManager.inputActions.Player);
    }

    void ChangeActionMap(InputActionMap actionMap)
    {
        actionMap.Enable();
    
        Debug.Log("Escape Menu UI using " + actionMap.name);
    }

    /*    public void ToggleOptionsMenu()
    {
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }*/

    public void ExitToMainMenu()
    {
        // exit save here?
        SceneManager.LoadScene("MainMenu");
    }
}