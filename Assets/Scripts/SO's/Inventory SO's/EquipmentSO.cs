using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New EquipmentSO", menuName = "Inventory/EquipmentSO")]
public class EquipmentSO : ScriptableObject
{
    public List<EquipmentItem> currentEquipment = new List<EquipmentItem>();

    public void ClearEquipment()
    {
        currentEquipment.Clear();
    }
}