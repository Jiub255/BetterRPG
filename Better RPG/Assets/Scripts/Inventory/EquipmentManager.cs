using UnityEngine;

public class EquipmentManager : MonoBehaviour, IDataPersistence
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
            // Change weapon sprite on player
            if (equipmentItem.equipmentTypeSO == weaponEquipmentType)
                spriteRenderer.sprite = equipmentItem.itemIconSprite;
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
        ChangeWeaponSprite(newItem);
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
        ChangeWeaponSprite(null);
    }

    public void ChangeWeaponSprite(EquipmentItem equipmentItem)
    {
        if (equipmentItem == null)
        {
            spriteRenderer.sprite = null;
            return;
        }

        if (equipmentItem.equipmentTypeSO == weaponEquipmentType)
        {
            spriteRenderer.sprite = equipmentItem.itemIconSprite;
        }
    }

    public void ClearEquipment()
    {
        equipmentSO.currentEquipment.Clear();
    }

    public void LoadData(GameData data)
    {
        equipmentSO.currentEquipment.Clear();

        foreach (EquipmentItem equipmentItem in data.currentEquipment)
        {
            equipmentSO.currentEquipment.Add(equipmentItem);
            ChangeWeaponSprite(equipmentItem);
        }

        onEquipChanged.Raise();
    }

    public void SaveData(GameData data)
    {
        data.currentEquipment.Clear();

        foreach (EquipmentItem equipmentItem in equipmentSO.currentEquipment)
        {
            data.currentEquipment.Add(equipmentItem);
        }
    }
}