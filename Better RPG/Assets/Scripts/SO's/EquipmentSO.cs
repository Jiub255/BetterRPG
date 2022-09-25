using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentSO", menuName = "Inventory/EquipmentSO")]
public class EquipmentSO : ScriptableObject
{
    public List<EquipmentItem> currentEquipment;

    public delegate void OnEquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    // is this any better than above?
    public GameEventEquipmentItem newItm;
    public GameEventEquipmentItem oldItm;
    // or this?
    public GameEvent onEquipChanged;

    //Inventory inventory;

    public InventorySO inventorySO;
    public GameObject weapon;

    private void OnEnable()
    {
       // EquipmentItem.OnEquipmentChanged += Equip;
    }

    private void Start()
    {
      //  inventory = MasterSingleton.Instance.Inventory;

        //  int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new List<EquipmentItem>();
    }

    public void Equip(EquipmentItem newItem)
    {
        // int slotIndex = (int)newItem.equipmentType;
        EquipmentTypeSO type = newItem.equipmentTypeSO;

        EquipmentItem oldItem = null;

        /*foreach (EquipmentItem equipmentItem in currentEquipment)*/
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            // if there is something already equipped in this slot
            if (type.equipmentType == currentEquipment[i].equipmentTypeSO.equipmentType)
            {
                // add old item to invSO
                oldItem = currentEquipment[i];
                inventorySO.Add(oldItem);
                // remove old item from equipmentSO
                currentEquipment.Remove(oldItem);
            }
        }

        // add new item to equipmentSO
        currentEquipment.Add(newItem);

        /*if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }*/

        //currentEquipment[slotIndex] = newItem;

        ChangeEquipmentSprite(newItem);


        // only need one of these signals
        onEquipmentChanged?.Invoke(newItem, oldItem);

        //SO gameEvent style
        // sends out signals with new/old item info. 
        newItm.Raise(newItem);
        oldItm.Raise(oldItem);

        // Equipment UI, statManager, statsUI, inventorySO, InventoryUI, all need listeners for this
        onEquipChanged.Raise();
    }

    public void Unequip(/*int slotIndex*/ EquipmentItem equipmentItem)
    {
        EquipmentTypeSO type = equipmentItem.equipmentTypeSO;
        EquipmentItem oldItem = null;

        /*foreach (EquipmentItem equipmentItem in currentEquipment)*/
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            // if there is something equipped in this slot
            if (type.equipmentType ==
                /*equipmentItem*/currentEquipment[i].equipmentTypeSO.equipmentType)
            {
                oldItem = /*equipmentItem*/currentEquipment[i];
                inventorySO.Add(oldItem);
                currentEquipment.Remove(oldItem);

                onEquipmentChanged?.Invoke(null, oldItem);

                newItm.Raise(null);//???
                oldItm.Raise(oldItem);
            }
        }

        UnequipSprite();
        /*        if (currentEquipment[slotIndex] != null)
                {
                    Equipment oldItem = currentEquipment[slotIndex];
                    inventory.Add(oldItem);

                    currentEquipment[slotIndex] = null;

                    onEquipmentChanged?.Invoke(null, oldItem);
                }*/
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            Unequip(currentEquipment[i]);
        }
    }

    public void ClearEquipment()
    {
        currentEquipment.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public void ChangeEquipmentSprite(EquipmentItem newItem)
    {
        weapon.GetComponent<SpriteRenderer>().sprite = newItem.icon;
    }

    public void UnequipSprite()
    {
        weapon.GetComponent<SpriteRenderer>().sprite = null;
    }
}