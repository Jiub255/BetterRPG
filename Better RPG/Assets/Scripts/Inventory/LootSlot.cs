using UnityEngine;
using UnityEngine.UI;

public class LootSlot : MonoBehaviour
{
    public Image icon;
    public Button takeItemButton;

    Item item;

    public GameEventItem onClickTakeItemButton;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.itemIconSprite;
        icon.enabled = true;
        takeItemButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        takeItemButton.interactable = false;
    }

    public void TakeItem()
    {
        // heard by inventorymanager (Adds item) and playerlootmanager (removes from droploot)
        onClickTakeItemButton.Raise(item);
    }
}