using UnityEngine;

public class PlayerInventoryManager : InventoryManager
{
    [SerializeField]
    private GameObject itemPickup;

    public void DropItem(Item item)
    {
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.itemIconSprite;
        droppedItem.GetComponent<ItemPickup>().item = item;
        Remove(item, playerInventorySO);
    }

    public void AddToPlayerInventory(Item item)
    {
        Add(item, playerInventorySO);
    }

    public void RemoveFromPlayerInventory(Item item)
    {
        Remove(item, playerInventorySO);
    }
}