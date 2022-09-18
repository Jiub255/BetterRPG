using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentType", menuName = "Inventory/EquipmentType")]
public class EquipmentTypeSO : ScriptableObject
{
    // better to be serialize field private?
    public string equipmentType;

}