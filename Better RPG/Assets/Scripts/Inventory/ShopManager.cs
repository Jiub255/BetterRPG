using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put an instance of this on each merchant
// can have different shopInvSO's to manage their inventories
public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private InventorySO shopInventory;
    [SerializeField]
    private InventorySO playerInventory;

    [SerializeField]
    private GameEvent onShopItemsChanged;

    // There might be issues with item.amount.
    // Could amount be stored in inventory scripts instead of on the SO?
    // Or in InventorySO as a dictionary<Item, int> where int is amount.
    public void Buy(Item item)
    {
        // Add one to playerInventory's item.
        if (playerInventory.inventoryList.Contains(item))
        {
            item.amount += 1;
        }
        else
        {
            playerInventory.inventoryList.Add(item);
            item.amount = 1;
        }

        // Take one from shopInventory's item.
        item.amount -= 1;

        if (item.amount <= 0)
        {
            shopInventory.inventoryList.Remove(item);
        }

        // shopUI needs to hear this.
        onShopItemsChanged.Raise();
    }

    public void Remove(Item item)
    {
        // Take one from playerInventory's item.
        item.amount -= 1;

        if (item.amount <= 0)
        {
            playerInventory.inventoryList.Remove(item);
        }

        // Add one to shopInventory's item.
        if (shopInventory.inventoryList.Contains(item))
        {
            item.amount += 1;
        }
        else
        {
            shopInventory.inventoryList.Add(item);
            item.amount = 1;
        }

        // shopUI needs to hear this.
        onShopItemsChanged.Raise();
    }
}