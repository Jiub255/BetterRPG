using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory/Equipment Item")]
public class EquipmentItem : Item
{
    public EquipmentTypeSO equipmentTypeSO;
    public int defenseModifier;
    public int attackModifier;

    public GameEventEquipmentItem OnUseEquipmentItem;

    public override void Use()
    {
        base.Use();

        // remove from inventory

        // do this first in case inventory is full, makes space for the old item
        RemoveFromInventory();

        // Equipmanager listens for this, equips item
        OnUseEquipmentItem.Raise(this);
    }
}