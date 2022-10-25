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

    Item item;

    public GameEventItem onDropItem;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.itemIconSprite;
        icon.enabled = true;
        useButton.interactable = true;
        removeButton.interactable = true;

        if (newItem.amount == 1)
        {
            amountText.text = "";
        }
        else
        {
            amountText.text = newItem.amount.ToString();
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        useButton.interactable = false;
        removeButton.interactable = false;
        amountText.text = "";
    }

    public void OnRemoveButton()
    {
        onDropItem.Raise(item);
    }

    public void OnUseButton()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}