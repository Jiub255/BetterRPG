using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button useButton;
    public Button removeButton;
    public TextMeshProUGUI amountText;

    ItemAmount itemAmount;

    public GameEventItem onDropItem;

    public void AddItem(ItemAmount newItemAmount)
    {
        itemAmount = newItemAmount;

        icon.sprite = itemAmount.item.itemIconSprite;
        icon.enabled = true;
        useButton.interactable = true;
        removeButton.interactable = true;

        if (newItemAmount.amount == 1)
        {
            amountText.text = "";
        }
        else
        {
            amountText.text = newItemAmount.amount.ToString();
        }
    }

    public void ClearSlot()
    {
        itemAmount = null;

        icon.sprite = null;
        icon.enabled = false;
        useButton.interactable = false;
        removeButton.interactable = false;
        amountText.text = "";
    }

    public void OnRemoveButton()
    {
        onDropItem.Raise(itemAmount.item);
    }

    public void OnUseButton()
    {
        if (itemAmount != null)
        {
            itemAmount.item.Use();
        }
    }
}