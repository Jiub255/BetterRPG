using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI2;

    InventorySlot[] slots;

    //for pausing gameplay
    public static event Action OnToggleInventory;

    public InventorySO inventorySO;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();
    }

    // maybe have an input manager script that can trigger this?
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI2.SetActive(!inventoryUI2.activeSelf);
            OnToggleInventory?.Invoke();
        }
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