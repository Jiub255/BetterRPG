using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : Interactable
{
    public Item item;

    public GameEventItem OnPickUp;

    public override void Interact()
    {
        base.Interact();

        OnPickUp.Raise(item);

        Destroy(gameObject);

        //Pickup();
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