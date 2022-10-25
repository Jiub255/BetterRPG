using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public EquipmentSO equipmentSO;

    public GameEvent onEquipChanged;
    public GameEventEquipmentItem onEquip;
    public GameEventEquipmentItem onUnequip;

    public SpriteRenderer spriteRenderer;

    public EquipmentTypeSO weaponEquipmentType;

    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        foreach (EquipmentItem equipmentItem in equipmentSO.currentEquipment)
        {
            // StatManager will listen for this, to add modifiers from new item
            // is this necessary? or will it double add modifiers?
            onEquip.Raise(equipmentItem);

            // Change weapon sprite on player
            if (equipmentItem.equipmentTypeSO == weaponEquipmentType)
                spriteRenderer.sprite = equipmentItem.icon;
        }
    }

    public void Equip(EquipmentItem newItem)
    {
        EquipmentTypeSO type = newItem.equipmentTypeSO;

        // if there is something equipped in this slot, unequip it
        for (int i = 0; i < equipmentSO.currentEquipment.Count; i++)
        {
            if (type.equipmentType == equipmentSO.currentEquipment[i].equipmentTypeSO.equipmentType)
            {
                EquipmentItem oldItem = equipmentSO.currentEquipment[i];

                Unequip(oldItem);
            }
        }

        // add new item to equipSO
        equipmentSO.currentEquipment.Add(newItem);

        // EquipUI will listen for this, to update its UI based off the new equipSO
        // will this work? the SO only gets changed one little tick before this
        onEquipChanged.Raise();

        // StatManager will listen for this, to add modifiers from new item
        onEquip.Raise(newItem);

        // Change weapon sprite on player
        if (newItem.equipmentTypeSO == weaponEquipmentType)
            spriteRenderer.sprite = newItem.icon;
    }

    // have unequip button in EquipUI call this function
    public void Unequip(EquipmentItem itemToUnequip)
    {
        // remove item from EquipSO
        equipmentSO.currentEquipment.Remove(itemToUnequip);

        // EquipmentUI will listen for this, to updateUI
        onEquipChanged.Raise();

        // InventoryManager will listen for this, to add item to invSO
        // StatManager will listen for this, to remove modifiers from new item
        onUnequip.Raise(itemToUnequip);

        // Change weapon sprite on player
        if (itemToUnequip.equipmentTypeSO == weaponEquipmentType)
            spriteRenderer.sprite = null;
    }

    public void ClearEquipment()
    {
        equipmentSO.currentEquipment.Clear();
    }
}