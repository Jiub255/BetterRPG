using UnityEngine;

public class PlayerInventoryManager : InventoryManager
{
    [SerializeField]
    private GameObject itemPickup;

    public void DropItem(ItemSO item)
    {
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.itemIconSprite;
        droppedItem.GetComponent<ItemPickup>().item = item;
        Remove(item, playerInventorySO);
    }

    public void AddToPlayerInventory(ItemSO item)
    {
        Add(item, playerInventorySO);
    }

    public void RemoveFromPlayerInventory(ItemSO item)
    {
        Remove(item, playerInventorySO);
    }
}