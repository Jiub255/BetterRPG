using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO inventorySO;

    public GameEvent onItemChanged;

    // not sure if i want a limit, keep it for now
    public int space = 20;

    public GameObject itemPickup;

    public void Add(Item item)
    {
        if (inventorySO.inventoryList.Count >= space)
        {
            Debug.Log("Not enough room");
            Debug.Log("Add method returned false");
            //return false;
        }

        inventorySO.inventoryList.Add(item);

        // inv UI manager needs to hear this
        onItemChanged.Raise();

        Debug.Log("Add method returned true");
        //return true;
    }

    public void Remove(Item item)
    {
        inventorySO.inventoryList.Remove(item);

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
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.icon;
        droppedItem.GetComponent<ItemPickup>().item = item;
        Remove(item);
    }
}