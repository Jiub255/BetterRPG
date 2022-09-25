using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory/Equipment Item")]
public class EquipmentItem : Item
{
    // public EquipmentSlot equipmentSlot;

    public EquipmentTypeSO equipmentTypeSO;
    public int defenseModifier;
    public int attackModifier;

    public delegate void OnEquipmentChanged(EquipmentItem equipmentItem);
    public OnEquipmentChanged onEquipmentChangedCallback;

    public GameEventEquipmentItem OnUseEquipmentItem;

    public override void Use()
    {
        base.Use();

        // remove from inventory
        // do this first in case inventory is full, makes space for the old item
        RemoveFromInventory();

        OnUseEquipmentItem.Raise(this);
       // onEquipmentChangedCallback?.Invoke(this);

       // RemoveFromInventory();

        // equip the item



       // MasterSingleton.Instance.EquipmentManager.Equip(this);
    }
}

/*public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Feet
}*/