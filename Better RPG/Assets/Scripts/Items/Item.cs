using UnityEngine;

// have usable item and equipment item subclasses
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    [TextArea(3, 20)]
    public string itemDescription = "Item Description";

    public Sprite itemIconSprite = null;

    public GameEventItem onRemoveItem;

    // stackable stuff
    public int amount = 1;

    // Maybe have a shopAmount here? No then you'd need one for each shop.
    // Think I need to store amount in InventoryManager.
    // Could have it's own list there, and build it from SO list, but also keep track of amounts?

    public virtual void Use()
    {
        // use the item
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        // InvManager listens for this, removes from InvSO
        onRemoveItem.Raise(this);
    }
}