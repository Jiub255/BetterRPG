using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI2;

    InventorySlot[] slots;

    //for pausing gameplay
    public static event Action OnToggleInventory;

    public InventorySO inventorySO;


    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction openInventory;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        openInventory = playerControls.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenInventory;
    }

    private void OnDisable()
    {
        openInventory.Disable();
    }

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();
    }

    void OpenInventory(InputAction.CallbackContext context)
    {
        inventoryUI2.SetActive(!inventoryUI2.activeSelf);
        OnToggleInventory?.Invoke();
    }

    public void UpdateUI()
    {
        Debug.Log("Updating Inventory UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventorySO.inventoryList.Count)
            {
                slots[i].AddItem(inventorySO.inventoryList[i]);
                //Debug.Log("Added item to slot#" + i);
            }
            else
            {
                slots[i].ClearSlot();
               // Debug.Log("Cleared slot#" + i);
            }
        }
    }
}