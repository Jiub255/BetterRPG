using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventorySO", menuName = "Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public List<Item> inventoryList = new List<Item>();

    // Maybe do a dictionary instead? With <Item, int> where int is amount.
    //public Dictionary<Item, int> inventoryWithAmounts = new Dictionary<Item, int>();

    // Try using a list of ItemAmounts instead, custom class that just stores an Item and int amount.
    public List<ItemAmount> inventoryWithAmountsList = new List<ItemAmount>();

    public void ClearInventory()
    {
        inventoryList.Clear();
    }
}