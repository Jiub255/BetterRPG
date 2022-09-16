using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        // remove from inventory
        // do this first in case inventory is full, makes space for the old item
        RemoveFromInventory();

        // equip the item
        MasterSingleton.Instance.EquipmentManager.Equip(this);
    }
}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Feet
}