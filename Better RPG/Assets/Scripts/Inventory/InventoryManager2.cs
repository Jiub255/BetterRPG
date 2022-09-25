using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager2 : MonoBehaviour
{
    public InventorySO2 inventorySO2;
    //public List<Item> inventoryList = new List<Item>();

/*    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;*/

    // new SO-style
    public GameEvent onItemChanged;

    public int space = 20;


    public bool Add(Item item)
    {
        if (inventorySO2.inventoryList.Count >= space)
        {
            Debug.Log("Not enough room");
            Debug.Log("Add method returned false");
            return false;
        }

        inventorySO2.inventoryList.Add(item);

       // onItemChangedCallback?.Invoke();

        // inv UI manager needs to hear this
        onItemChanged.Raise();

        Debug.Log("Add method returned true");
        return true;
    }

    public void Remove(Item item)
    {
        inventorySO2.inventoryList.Remove(item);

       // onItemChangedCallback?.Invoke();

        // inv UI manager needs to hear this
        onItemChanged.Raise();
    }

    public void ClearInventory()
    {
        inventorySO2.inventoryList.Clear();
    }
}