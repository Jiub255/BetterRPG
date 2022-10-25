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
   // public GameEventItem onTryToLootItem;
   // public GameEventItem onLootItem;

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
/*
    public void TryToLootItem()
    {
        // InvManager listens, signals back if there's room
        onTryToLootItem.Raise(this);
    }

    // listen for there's room signal from invManager
    private void LootItem()
    {
        // InvManager listens, adds to inv

        // remove from LootMenuUI, maybe list too?
    }*/
}