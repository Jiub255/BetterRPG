using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventorySO", menuName = "Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public List<Item> inventoryList = new List<Item>();

    public void ClearInventory()
    {
        inventoryList.Clear();
    }
}