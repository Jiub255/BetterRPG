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

    [SerializeField] 
    public GameEvent dontAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropLoot>() && collision.isActiveAndEnabled && collision.CompareTag("Dead"))
        {
            // don't add empty dropLoots to list, don't want to display them
            if (collision.GetComponent<DropLoot>().itemsToDrop.Count > 0)
            {
                dropLoots.Add(collision.GetComponent<DropLoot>());
            }

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

            // if currentDropLoot is now empty, remove from UI
            if (currentDropLoot.itemsToDrop.Count == 0)
            {
                dropLoots.Remove(currentDropLoot);

                // if there's another nonempty dropLoot, display that in UI
                if (dropLoots.Count > 0)
                {
                    // do i need dontAttack signal here?

                    currentDropLootIndex = 0;
                    currentDropLoot = dropLoots[currentDropLootIndex];
                }
                else // if there are no nonempty dropLoots, close LootMenuUI
                {
                    // send dontAttack signal since the menu closes without you being able to move mouse off of button
                    // or just move mouse through code? no that's dumb
                    dontAttack.Raise();

                    currentDropLootIndex = 0;
                    currentDropLoot = null;
                    onCloseLootMenu.Raise();
                }
            }
        }

        // update UI
        onDropLootChanged.Raise(currentDropLoot);
    }
}