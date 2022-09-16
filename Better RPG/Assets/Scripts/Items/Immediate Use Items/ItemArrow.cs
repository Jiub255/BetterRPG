public class ItemArrow : Interactable
{
    public int numberOfArrows = 1;

    public override void Interact()
    {
        base.Interact();

        UseItem();
    }

    private void UseItem()
    {
        MasterSingleton.Instance.Inventory.arrows += numberOfArrows;
    }
}