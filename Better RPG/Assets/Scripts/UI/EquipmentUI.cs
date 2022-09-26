using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform equipmentParent;

    public GameObject equipmentUIpanel;

    EquipmentSlot[] equipmentSlots;

    public EquipmentSO equipmentSO;

    // will this work in start? should i use awake? onEnable? what about when changing scenes?
    void Start()
    {
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();

        UpdateUI();
    }

    // do this from input manager
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            equipmentUIpanel.SetActive(!equipmentUIpanel.activeSelf);
        }
    }

    public void UpdateUI()
    {
        Debug.Log("Updating Equipment UI");

        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        {
            //get slot's equipment type
            EquipmentTypeSO slotType = equipmentSlot.equipmentType;

            bool slotTypeEquipped = false;

            // for each currently equipped item
            foreach (EquipmentItem currentlyEquippedItem in equipmentSO.currentEquipment)
            {
                /*Debug.Log("slot type: " + slotType.equipmentType + " currently equipped type: "
                    + currentlyEquippedItem.equipmentTypeSO.equipmentType);*/

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
