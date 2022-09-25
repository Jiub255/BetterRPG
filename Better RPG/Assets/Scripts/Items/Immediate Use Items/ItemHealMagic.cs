using UnityEngine;

public class ItemHealMagic : Interactable
{
    public int amount = 1;
    PlayerStats playerStats;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);
        playerStats = collision.gameObject.GetComponent<PlayerStats>();
        UseItem();
    }

    private void UseItem()
    {
        playerStats.ChangeMagic(amount);
        //MasterSingleton.Instance.Player.GetComponent<PlayerStats>().ChangeMagic(amount);
    }
}