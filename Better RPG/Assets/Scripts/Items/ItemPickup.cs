using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : Interactable
{
    public Item item;

    public GameEventItem OnPickUp;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);

        // InvManager listens for this, adds item to inv
        OnPickUp.Raise(item);

        Destroy(gameObject);
    }
}