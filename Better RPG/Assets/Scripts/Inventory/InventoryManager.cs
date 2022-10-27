using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
{
    public InventorySO playerInventorySO;

    public GameEvent onItemChanged;

    public void Add(Item item, InventorySO inventory)
    {
        foreach (ItemAmount itemAmount in inventory.inventoryWithAmountsList)
        {
            if (itemAmount.item == item)
            {
                itemAmount.amount += 1;
                return;
            }
        }

        // Adds blank ItemAmount to invSO list, sets item to item, sets amount to 1.
        inventory.AddItemAmountToList(item);

        // InventoryUI managers need to hear this so they'll update based on their SO's.
        onItemChanged.Raise();
    }

    public void Remove(Item item, InventorySO inventory)
    {
        foreach (ItemAmount itemAmount in inventory.inventoryWithAmountsList)
        {
            if (itemAmount.item == item)
            {
                itemAmount.amount -= 1;

                if (itemAmount.amount <= 0)
                {
                    inventory.inventoryWithAmountsList.Remove(itemAmount);
                    break;
                }
            }
        }

        // InventoryUI managers need to hear this so they'll update based on their SO's.
        onItemChanged.Raise();
    }

    public void ClearInventory(InventorySO inventory)
    {
        inventory.inventoryWithAmountsList.Clear();
    }
}