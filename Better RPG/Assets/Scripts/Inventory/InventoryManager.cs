using UnityEngine;

public abstract class InventoryManager : MonoBehaviour
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
}