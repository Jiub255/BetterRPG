public class ItemHealing : Interactable
{
    public int healingAmount = 1;

    public override void Interact()
    {
        base.Interact();

        UseItem();
    }

    private void UseItem()
    {
        MasterSingleton.Instance.Player.GetComponent<PlayerStats>().ChangeHealth(healingAmount);
    }
}