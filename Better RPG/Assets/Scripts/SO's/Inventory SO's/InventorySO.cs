using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New InventorySO", menuName = "Inventory/InventorySO")]
public class InventorySO : ScriptableObject
{
    public List<ItemAmount> inventoryWithAmountsList = new List<ItemAmount>();

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventoryWithAmountsList.Count; i++)
        {
            if (inventoryWithAmountsList[i].item == item)
            {
                inventoryWithAmountsList[i].amount++;
            }
        }

        AddNewItemToList(item);
    }

    public void AddNewItemToList(Item item)
    {
        ItemAmount blank = new ItemAmount();

        blank.item = item;
        blank.amount = 1;

        inventoryWithAmountsList.Add(blank);
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < inventoryWithAmountsList.Count; i++)
        {
            if (inventoryWithAmountsList[i].item == item)
            {
                inventoryWithAmountsList[i].amount--;

                if (inventoryWithAmountsList[i].amount <= 0)
                {
                    inventoryWithAmountsList.Remove(inventoryWithAmountsList[i]);
                }
            }
        }
    }

    public void ClearInventory()
    {
        inventoryWithAmountsList.Clear();
    }
}