using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventorySO2", menuName = "Inventory/InventorySO2")]
public class InventorySO2 : ScriptableObject
{
    public List<Item> inventoryList = new List<Item>();
}