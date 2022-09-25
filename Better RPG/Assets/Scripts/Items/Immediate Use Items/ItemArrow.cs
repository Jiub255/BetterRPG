using UnityEngine;

public class ItemArrow : Interactable
{
    public int numberOfArrows = 1;
    InventorySO inventorySO;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);
        inventorySO = collision.gameObject.GetComponent<InventorySO>();
        UseItem();
    }

    private void UseItem()
    {
        inventorySO.AddArrows(numberOfArrows);
        //MasterSingleton.Instance.Inventory.arrows += numberOfArrows;
    }
}