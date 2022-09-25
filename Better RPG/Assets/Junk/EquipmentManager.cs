using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
/*    #region Singleton

    private static EquipmentManager instance;

    public static EquipmentManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("more than one instance of EquipmentManager found");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion*/

    public List<EquipmentItem> currentEquipment;

    public delegate void OnEquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = MasterSingleton.Instance.Inventory;

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
            // if there is something equipped in this slot
            if (type.equipmentType == currentEquipment[i].equipmentTypeSO.equipmentType)  
            { 
                oldItem = currentEquipment[i];
                inventory.Add(oldItem);
                currentEquipment.Remove(oldItem);
            }
        }

        currentEquipment.Add(newItem);

        /*if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }*/

        //currentEquipment[slotIndex] = newItem;

        onEquipmentChanged?.Invoke(newItem, oldItem);
    }

    public void Unequip(/*int slotIndex*/ EquipmentItem equipment)
    {
        EquipmentTypeSO type = equipment.equipmentTypeSO;
        EquipmentItem oldItem = null;

        /*foreach (EquipmentItem equipmentItem in currentEquipment)*/
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            // if there is something equipped in this slot
            if (type.equipmentType == 
                /*equipmentItem*/currentEquipment[i].equipmentTypeSO.equipmentType) 
            {
                oldItem = /*equipmentItem*/currentEquipment[i];
                inventory.Add(oldItem);
                currentEquipment.Remove(oldItem);

                onEquipmentChanged?.Invoke(null, oldItem);
            }
        }
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}