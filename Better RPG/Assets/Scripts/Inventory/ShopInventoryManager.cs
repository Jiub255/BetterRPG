using System;
using UnityEngine;

// put an instance of this on each merchant
// can have different shopInvSO's to manage their inventories

// Maybe use invManager base class and have this and InventoryManager inherit
// Could use for trading with NPCs, maybe even chests/containers
public class ShopInventoryManager : InventoryManager
{
    public InventorySO shopInventorySO { get; private set; }

    public static event Action<InventorySO> OnShopChanged;

    private void OnEnable()
    {
        ShopSlot.OnBuyItem += Buy;
        ShopSlot.OnSellItem += Sell;
    }

    private void OnDisable()
    {
        ShopSlot.OnBuyItem -= Buy;
        ShopSlot.OnSellItem -= Sell;
    }

    public void Buy(ItemSO item)
    {
        // Add one to playerInventory's item.
        Add(item, playerInventorySO);

        // Take one from shopInventory's item.
        Remove(item, shopInventorySO);

        // ShopUI listens and updates
        OnShopChanged?.Invoke(shopInventorySO);
    }

    public void Sell(ItemSO item)
    {
        // Take one from playerInventory's item.
        Remove(item, playerInventorySO);

        // Add one to shopInventory's item.
        Add(item, shopInventorySO);

        // ShopUI listens and updates
        OnShopChanged?.Invoke(shopInventorySO);
    }
}