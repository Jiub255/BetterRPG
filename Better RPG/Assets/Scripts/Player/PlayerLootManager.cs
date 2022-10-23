using System.Collections.Generic;
using UnityEngine;

public class PlayerLootManager : MonoBehaviour
{
    public List<DropLoot> dropLoots = new List<DropLoot>();

    public DropLoot currentDropLoot;

    // need this for going to the next/previous drop loot from UI button?
    public int currentDropLootIndex;

    [SerializeField]
    private GameEventDropLoot onDropLootChanged;
    [SerializeField]
    private GameEvent onOpenLootMenu;
    [SerializeField]
    private GameEvent onCloseLootMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropLoot>() && collision.isActiveAndEnabled && collision.CompareTag("Dead"))
        {
            dropLoots.Add(collision.GetComponent<DropLoot>());

            if (dropLoots.Count == 1)
            {
                currentDropLootIndex = 0;

                currentDropLoot = collision.GetComponent<DropLoot>();

                // send signal(s) to UI to update/open
                onDropLootChanged.Raise(currentDropLoot);
                onOpenLootMenu.Raise();
            }

            onDropLootChanged.Raise(currentDropLoot);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DropLoot>() && collision.isActiveAndEnabled && collision.CompareTag("Dead"))
        {
            dropLoots.Remove(collision.GetComponent<DropLoot>());

            if (dropLoots.Count > 0)
            {
                currentDropLoot = dropLoots[0];

                // update UI
                onDropLootChanged.Raise(currentDropLoot);
            }
            else
            {
                currentDropLoot = null;

                // update UI/ close UI
                // will this work when currentDropLoot == null? 
                onDropLootChanged.Raise(currentDropLoot);
                onCloseLootMenu.Raise();
            }
        }
    }

    // gets called by button on LootMenuUI
    public void ChangeCurrentDropLootIndex(int indexChangeAmount)
    {
        currentDropLootIndex += indexChangeAmount;

        if (currentDropLootIndex >= dropLoots.Count)
        {
            currentDropLootIndex = 0;
        }
        if (currentDropLootIndex < 0)
        {
            currentDropLootIndex = dropLoots.Count - 1;
        }

        currentDropLoot = dropLoots[currentDropLootIndex];

        // send signal(s) to UI to update
        onDropLootChanged.Raise(currentDropLoot);
    }

    // listens for OnClickTakeItemButton from LootSlot
    public void TakeItem(Item item)
    {
        if (currentDropLoot.itemsToDrop.Contains(item))
        {
            currentDropLoot.itemsToDrop.Remove(item);
        }

        // update UI
        onDropLootChanged.Raise(currentDropLoot);
    }
}