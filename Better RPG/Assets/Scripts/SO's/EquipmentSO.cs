using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentSO", menuName = "Inventory/EquipmentSO")]
public class EquipmentSO : ScriptableObject
{
    public List<EquipmentItem> currentEquipment = new List<EquipmentItem>();

    public void ClearEquipment()
    {
        currentEquipment.Clear();
    }
}