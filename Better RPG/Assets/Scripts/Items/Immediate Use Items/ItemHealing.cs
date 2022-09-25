using UnityEngine;

public class ItemHealing : Interactable
{
    public int healingAmount = 1;
    PlayerStats playerStats;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);
        playerStats = collision.gameObject.GetComponent<PlayerStats>();
        UseItem();
    }

    private void UseItem()
    {
        playerStats.ChangeHealth(healingAmount);
        //MasterSingleton.Instance.Player.GetComponent<PlayerStats>().ChangeHealth(healingAmount);
    }
}