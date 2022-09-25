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

    public InventorySO playerInventorySO;

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
        playerInventorySO.Remove(item);
        onDropItem.Raise(item);
        //MasterSingleton.Instance.Inventory.Remove(item);
    }

/*    public void DropItem(Item item)
    {
        Vector3 playerPosition = new Vector3(playerStats.transform.position.x, playerStats.transform.position.y - 1, 0);
        GameObject droppedItem = Instantiate(itemPickup, playerPosition, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.icon;
        droppedItem.GetComponent<ItemPickup>().item = item;
        UpdateUI();
    }*/

    public void OnUseButton()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}