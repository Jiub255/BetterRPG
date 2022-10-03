using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button useButton;
    public Button removeButton;

    Item item;

    public GameEventItem onDropItem;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        useButton.interactable = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        useButton.interactable = false;
        removeButton.interactable = false;
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