public class ItemCoin : Interactable
{
    public int value = 1;

    public override void Interact()
    {
        base.Interact();

        UseItem();
    }

    private void UseItem()
    {
        MasterSingleton.Instance.Inventory.money += value;
    }
}