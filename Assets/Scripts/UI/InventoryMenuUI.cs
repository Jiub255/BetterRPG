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

    // need this to have grid layout work on newly activated inv slots
    // kind of hacky but it works
    [SerializeField]
    private GameEvent onItemChanged;

    // new input system stuff
    InputAction openInventory;
    InputAction closeInventory;

    private void OnEnable()
    {
        openInventory = InputManager.inputActions.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenInventoryMenu;

/*        closeInventory = InputManager.inputActions.UI.CloseInventory;
        closeInventory.Enable();
        closeInventory.performed += CloseInventoryMenu;*/
    }

    private void OnDisable()
    {
        openInventory.Disable();
        openInventory.performed -= OpenInventoryMenu;

/*        closeInventory.Disable();
        closeInventory.performed -= CloseInventoryMenu;*/
    }

    void OpenInventoryMenu(InputAction.CallbackContext context)
    {
        //Debug.Log("Open Inv Menu");

        ToggleInventoryPanels(true);
        HUDPanel.SetActive(false);
        OnTogglePause?.Invoke(true);
 //       InputManager.ChangeActionMap(InputManager.inputActions.UI);
        InputManager.invMenuOpen = true;

        onItemChanged.Raise();
    }

    void CloseInventoryMenu(InputAction.CallbackContext context)
    {
       // Debug.Log("Close Inv Menu");

        ToggleInventoryPanels(false);
        HUDPanel.SetActive(true);
        OnTogglePause?.Invoke(false);
 //       InputManager.ChangeActionMap(InputManager.inputActions.Player);
        InputManager.invMenuOpen = false;
    }

    public void ToggleInventoryPanels(bool active)
    {
        inventoryUIPanel.SetActive(active);
        equipmentUIPanel.SetActive(active);
        statsUIPanel.SetActive(active);
        magicUIPanel.SetActive(active);
    }
}