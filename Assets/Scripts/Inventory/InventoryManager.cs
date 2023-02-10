using UnityEngine;

public abstract class InventoryManager : MonoBehaviour, IDataPersistence
{
    public InventorySO playerInventorySO;

    public GameEvent onItemChanged;

    public void Add(ItemSO item, InventorySO inventory)
    {
        inventory.AddItem(item);

        // InventoryUI managers need to hear this so they'll update based on their SO's.
        onItemChanged.Raise();
    }

    public void Remove(ItemSO item, InventorySO inventory)
    {
        inventory.RemoveItem(item);

        // InventoryUI managers need to hear this so they'll update based on their SO's.
        onItemChanged.Raise();
    }

    public void ClearInventory(InventorySO inventory)
    {
        inventory.inventoryWithAmountsList.Clear();
    }

    public void LoadData(GameData data)
    {
        playerInventorySO.inventoryWithAmountsList.Clear();

        foreach (ItemAmount itemAmount in data.inventoryList)
        {
            playerInventorySO.inventoryWithAmountsList.Add(itemAmount);
        }

        // Update invUI?
        onItemChanged.Raise();
    }

    public void SaveData(GameData data)
    {
        data.inventoryList.Clear();

        foreach (ItemAmount itemAmount in playerInventorySO.inventoryWithAmountsList)
        {
            data.inventoryList.Add(itemAmount);
        }
    }
}