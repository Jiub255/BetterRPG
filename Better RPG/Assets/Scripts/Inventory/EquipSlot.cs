using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public Image icon;
    public Button unequipButton;

    Equipment equipmentItem;

    public void AddItem(Equipment newItem)
    {
        equipmentItem = newItem;

        icon.sprite = equipmentItem.icon;
        icon.enabled = true;
        unequipButton.interactable = true;
    }

    public void ClearSlot()
    {
        equipmentItem = null;

        icon.sprite = null;
        icon.enabled = false;
        unequipButton.interactable = false;
    }

    public void RemoveEquipment()
    {
        MasterSingleton.Instance.EquipmentManager.Unequip((int)equipmentItem.equipmentSlot);
    }
}
