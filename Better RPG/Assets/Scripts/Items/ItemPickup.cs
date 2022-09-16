using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up " + item.itemName);

        bool wasPickedUp = MasterSingleton.Instance.Inventory.Add(item);
        Debug.Log("wasPickedup == " + wasPickedUp);

        if (wasPickedUp)
            Destroy(gameObject);
    } 
}