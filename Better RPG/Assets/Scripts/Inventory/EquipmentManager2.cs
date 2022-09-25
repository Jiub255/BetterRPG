using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager2 : MonoBehaviour
{
    public EquipmentSO2 equipmentSO2;

    public GameEvent onEquipChanged;
    public GameEventEquipmentItem onUnequip;

    public void Equip(EquipmentItem newItem)
    {
        EquipmentTypeSO type = newItem.equipmentTypeSO;

        // if there is something equipped in this slot, unequip it
        for (int i = 0; i < equipmentSO2.currentEquipment.Count; i++)
        {
            if (type.equipmentType == equipmentSO2.currentEquipment[i].equipmentTypeSO.equipmentType)
            {
                EquipmentItem oldItem = equipmentSO2.currentEquipment[i];

                Unequip(oldItem);
            }
        }

        // add new item to equipSO
        equipmentSO2.currentEquipment.Add(newItem);

        // EquipUI will listen for this, to update its UI based off the new equipSO
        // will this work? the SO only gets changed one little tick before this
        onEquipChanged.Raise();
    }

    // have unequip button in EquipUI call this function
    public void Unequip(EquipmentItem itemToUnequip)
    {
        // add item to invSO
        onUnequip.Raise(itemToUnequip);

        // remove item from EquipSO
        equipmentSO2.currentEquipment.Remove(itemToUnequip);
    }

    public void ClearEquipment()
    {
        equipmentSO2.currentEquipment.Clear();
    }
}