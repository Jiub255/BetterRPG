public class ItemHealMagic : Interactable
{
    public int amount = 1;

    public override void Interact()
    {
        base.Interact();

        UseItem();
    }

    private void UseItem()
    {
        MasterSingleton.Instance.Player.GetComponent<PlayerStats>().ChangeMagic(amount);
    }
}