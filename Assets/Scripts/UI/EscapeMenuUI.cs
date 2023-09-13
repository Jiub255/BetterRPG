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
    InputAction openEscapeMenu;
    InputAction openEscapeMenuFromInv;
    InputAction closeEscapeMenu;

    [SerializeField] InventoryMenuUI inventoryMenuUI;

    private void Awake()
    {
        inventoryMenuUI = GetComponent<InventoryMenuUI>();
    }

    private void OnEnable()
    {
        openEscapeMenu = InputManager.inputActions.Player.OpenEscapeMenu;
        openEscapeMenu.Enable();
        openEscapeMenu.performed += OpenEscapeMenu;

/*        openEscapeMenuFromInv = InputManager.inputActions.UI.OpenEscapeMenu;
        openEscapeMenuFromInv.Enable();
        openEscapeMenuFromInv.performed += OpenEscapeMenu;*/

        closeEscapeMenu = InputManager.inputActions.EscapeMenu.CloseEscapeMenu;
        closeEscapeMenu.Enable();
        closeEscapeMenu.performed += CloseEscapeMenu;
    }

    private void OnDisable()
    {
        openEscapeMenu.Disable();
        openEscapeMenu.performed -= OpenEscapeMenu;

/*        openEscapeMenuFromInv.Disable();
        openEscapeMenuFromInv.performed -= OpenEscapeMenu;*/

        closeEscapeMenu.Disable();
        closeEscapeMenu.performed -= CloseEscapeMenu;
    }

    void OpenEscapeMenu(InputAction.CallbackContext context)
    {
        if (InputManager.invMenuOpen)
        {
            // close inv menu, stay paused
            inventoryMenuUI.ToggleInventoryPanels(false); // how to call this from here?
        }
        else // if inv menu isn't open
        {
            OnTogglePause?.Invoke(true);
            HUDPanel.SetActive(false);
        }

        EscapeMenuPanel.SetActive(true);
        InputManager.ChangeActionMap(InputManager.inputActions.EscapeMenu);
    }

    public void CloseEscapeMenu(InputAction.CallbackContext context)
    {
        CloseEscWithoutContext();
    }

    public void CloseEscWithoutContext()
    {
        if (InputManager.invMenuOpen)
        {
            // open inv menu, stay paused
            inventoryMenuUI.ToggleInventoryPanels(true);
 //           InputManager.ChangeActionMap(InputManager.inputActions.UI);
        }
        else
        {
            HUDPanel.SetActive(true);
            OnTogglePause?.Invoke(false);
            InputManager.ChangeActionMap(InputManager.inputActions.Player);
        }
        
        EscapeMenuPanel.SetActive(false);
    }

    public void ToggleOptionsMenu()
    {
        Debug.Log("Options Button Pressed");

/*        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);*/
    }

    public void ExitToMainMenu()
    {
        // exit save here?
        OnTogglePause.Invoke(false);
        InputManager.invMenuOpen = false;
        SceneManager.LoadScene("MainMenu");
    }
}