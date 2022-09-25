using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentSO2", menuName = "Inventory/EquipmentSO2")]
public class EquipmentSO2 : ScriptableObject
{
    public List<EquipmentItem> currentEquipment = new List<EquipmentItem>();
}