using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI2 : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject inventoryUI2;

    InventorySlot[] slots;

    public static event Action OnToggleInventory;

    public InventorySO inventorySO;

    void Start()
    {
        // trying the new way with SO game events
        //inventorySO.onItemChangedCallback += UpdateUI;

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

    public void UpdateInventory(Item newItem)
    {
        inventorySO.Add(newItem);

        UpdateUI();
    }

    public void UpdateInvRemove(Item item)
    {
        inventorySO.Remove(item);

        UpdateUI();
    }

    // should this method be on Item script?
/*    public void DropItem(Item item)
    {
        // gonna need a better way to find drop position. What if theres a wall just south of player?
        Vector3 playerPosition = new Vector3(playerStats.transform.position.x, playerStats.transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.icon;
        droppedItem.GetComponent<ItemPickup>().item = item;

        UpdateInvRemove(item);
    }*/

    public void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventorySO.inventoryList.Count)
            {
                slots[i].AddItem(inventorySO.inventoryList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}