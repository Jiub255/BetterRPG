using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform equipmentParent;

    EquipmentSlot[] equipmentSlots;

    public EquipmentSO equipmentSO;

    void Start()
    {
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        {
            //get slot's equipment type
            EquipmentTypeSO slotType = equipmentSlot.equipmentType;

            bool slotTypeEquipped = false;

            // for each currently equipped item
            foreach (EquipmentItem currentlyEquippedItem in equipmentSO.currentEquipment)
            {
                // if it's of the same type as the current slot
                // ie, if this slot does have equipment
                if (slotType.equipmentType == currentlyEquippedItem.equipmentTypeSO.equipmentType)
                {
                    // update current slot's display and functionality with equipped item
                    equipmentSlot.AddItem(currentlyEquippedItem);
                    slotTypeEquipped = true;
                }
            }

            // if current slot doesn't have equipment
            if (!slotTypeEquipped)
            {
                equipmentSlot.ClearSlot();
            }
        }
    }
}