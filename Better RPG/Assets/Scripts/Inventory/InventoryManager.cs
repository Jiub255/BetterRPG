using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO inventorySO;

    public GameEvent onItemChanged;

    public GameObject itemPickup;

    public void Add(Item item)
    {
        if (inventorySO.inventoryList.Contains(item))
        {
            item.amount += 1;
        }
        else
        {
            inventorySO.inventoryList.Add(item);
            item.amount = 1;
        }

        // inv UI manager needs to hear this
        onItemChanged.Raise();
    }

    public void Remove(Item item)
    {
        item.amount -= 1;
            
        if (item.amount <= 0)
        {
            inventorySO.inventoryList.Remove(item);
        }

        // inv UI manager needs to hear this
        onItemChanged.Raise();
    }

    public void ClearInventory()
    {
        inventorySO.inventoryList.Clear();
    }

    public void DropItem(Item item)
    {
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.itemIconSprite;
        droppedItem.GetComponent<ItemPickup>().item = item;
        Remove(item);
    }
}