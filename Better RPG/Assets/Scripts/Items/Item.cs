using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// have inventory item and equipment item subclasses?
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    [TextArea(3, 20)]
    public string itemDescription = "Item Description";
    public Sprite icon = null;

    public GameEventItem onRemoveItem;

    public virtual void Use()
    {
        // use the item
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        // InvManager listens for this, removes from InvSO(2)
        onRemoveItem.Raise(this);
    }

/*    public void DropItem(Item item)
    {
        // gonna need a better way to find drop position. What if theres a wall just south of player?
        Vector3 playerPosition = new Vector3(playerStats.transform.position.x, playerStats.transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.icon;
        droppedItem.GetComponent<ItemPickup>().item = item;

        UpdateInvRemove(item);
    }*/
}