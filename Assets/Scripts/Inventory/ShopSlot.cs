using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Button buySellButton;

    ItemSO item;

    public static event Action<ItemSO> OnBuyItem;
    public static event Action<ItemSO> OnSellItem;

    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.sprite = item.itemIconSprite;
        icon.enabled = true;
        buySellButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        buySellButton.interactable = false;
    }

    // Make two Shop Slot prefabs, one for BuyItem and one for SellItem.
    public void BuyItem()
    {
        // Send Item signal to ShopInventoryManager to Buy(item)
        OnBuyItem?.Invoke(item);
    }

    public void SellItem()
    {
        // Send Item signal to ShopInventoryManager to Sell(item)
        OnSellItem?.Invoke(item);
    }
}