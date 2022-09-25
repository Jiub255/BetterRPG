using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventorySO", menuName = "Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // new SO-style
    public GameEvent onItemChanged;

    public int space = 20;

    public List<Item> inventoryList = new List<Item>();

    int money;
    int arrows;

    public bool Add(Item item)
    {
        if (inventoryList.Count >= space)
        {
            Debug.Log("Not enough room");
            Debug.Log("Add method returned false");
            return false;
        }

        inventoryList.Add(item);

        onItemChangedCallback?.Invoke();

        // inv UI manager needs to hear this
        onItemChanged.Raise();

        Debug.Log("Add method returned true");
        return true;
    }

    public void Remove(Item item)
    {
        inventoryList.Remove(item);

        onItemChangedCallback?.Invoke();

        // inv UI manager needs to hear this
        onItemChanged.Raise();
    }

    public void ClearInventory()
    {
        inventoryList.Clear();
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
    public void AddArrows(int amount)
    {
        arrows += amount;
    }
}