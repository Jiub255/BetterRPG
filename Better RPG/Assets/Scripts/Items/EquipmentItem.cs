using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory/Equipment Item")]
public class EquipmentItem : ItemSO
{
    public GameEventEquipmentItem OnUseEquipmentItem;

    public EquipmentTypeSO equipmentTypeSO;

    [Header("Generally only for armor")]
    public int defenseModifier;

    [Header("Generally only for weapons")]
    public int attackModifier;
    public float knockbackForceModifier;
    public float knockbackDurationModifier;

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