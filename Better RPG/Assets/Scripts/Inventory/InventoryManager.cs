using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO inventorySO;

    public GameEvent onItemChanged;

    // not sure if i want a limit, keep it for now
    public int space = 20;

    public void Add(Item item)
    {
        if (inventorySO.inventoryList.Count >= space)
        {
            Debug.Log("Not enough room");
            Debug.Log("Add method returned false");
            //return false;
        }

        inventorySO.inventoryList.Add(item);

        // inv UI manager needs to hear this
        onItemChanged.Raise();

        Debug.Log("Add method returned true");
        //return true;
    }

    public void Remove(Item item)
    {
        inventorySO.inventoryList.Remove(item);

        // inv UI manager needs to hear this
        onItemChanged.Raise();
    }

    public void ClearInventory()
    {
        inventorySO.inventoryList.Clear();
    }
}