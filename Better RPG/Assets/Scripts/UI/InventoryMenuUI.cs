using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMenuUI : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    public GameObject equipmentUIPanel;
    public GameObject statsUIPanel;
    public GameObject magicUIPanel;
    public GameObject HUDPanel;

    //for pausing gameplay
    public static event Action<bool> OnTogglePause;

    // new input system stuff
    InputAction openInventory;
    InputAction closeInventory;
    InputAction closeAllMenus;

    private void OnEnable()
    {
        openInventory = InputManager.inputActions.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenInventoryMenu;

        closeInventory = InputManager.inputActions.UI.CloseInventory;
        closeInventory.Enable();
        closeInventory.performed += CloseInventoryMenu;
        
        closeAllMenus = InputManager.inputActions.UI.CloseAllMenus;
        closeAllMenus.Enable();
        closeAllMenus.performed += CloseInventoryMenu;


      //  InputManager.actionMapChange += ChangeActionMap;
    }

    private void OnDisable()
    {
        openInventory.Disable();
        openInventory.performed -= OpenInventoryMenu;

        closeInventory.Disable();
        closeInventory.performed -= CloseInventoryMenu;

        closeAllMenus.Disable();
        closeAllMenus.performed -= CloseInventoryMenu;
        // InputManager.actionMapChange -= ChangeActionMap;
    }

    // both open and close inv getting called when i press I (openInventory) in player action map

    void OpenInventoryMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Open Inv Menu");

        inventoryUIPanel.SetActive(true);
        equipmentUIPanel.SetActive(true);
        statsUIPanel.SetActive(true);
        magicUIPanel.SetActive(true);
        HUDPanel.SetActive(false);
        OnTogglePause?.Invoke(true);
        InputManager.ToggleActionMap(InputManager.inputActions.UI);
    }

    void CloseInventoryMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Close Inv Menu");

        inventoryUIPanel.SetActive(false);
        equipmentUIPanel.SetActive(false);
        statsUIPanel.SetActive(false);
        magicUIPanel.SetActive(false);
        HUDPanel.SetActive(true);
        OnTogglePause?.Invoke(false);
        InputManager.ToggleActionMap(InputManager.inputActions.Player);
    }

    void ChangeActionMap(InputActionMap actionMap)
    {
        actionMap.Enable();
    
        Debug.Log("Inv Menu UI using " + actionMap.name);
    }
}