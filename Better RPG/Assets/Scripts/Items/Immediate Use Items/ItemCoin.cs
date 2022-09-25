using UnityEngine;

public class ItemCoin : Interactable
{
    public int value = 1;
    InventorySO inventorySO;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);
        inventorySO = collision.gameObject.GetComponent<InventorySO>();
        UseItem();
    }

    private void UseItem()
    {
        inventorySO.AddMoney(value);
        //MasterSingleton.Instance.Inventory.money += value;
    }
}