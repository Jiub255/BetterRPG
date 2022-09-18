using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
/*    #region Singleton

    private static InventoryUI instance;
                  
    public static InventoryUI Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("more than one instance of InventoryUI found");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion*/

    public Transform itemsParent;
    public Transform equipmentParent;

    public GameObject inventoryUI;

    public PlayerStats playerStats;
    public Text healthText;
    public Text attackText;
    public Text defenseText;

    Inventory inventory;
    EquipmentManager equipmentManager;

    InventorySlot[] slots;
    EquipmentSlot[] equipmentSlots;

    public static event Action OnToggleInventory;

    // new SO inventory style stuff
    public InventorySO inventorySO;
    public EquipmentSO equipmentSO;

    void Start()
    {
        inventorySO.onItemChangedCallback += UpdateUI;

        /*inventory = MasterSingleton.Instance.Inventory;
        inventory.onItemChangedCallback += UpdateUI;*/

        equipmentSO.onEquipmentChanged += UpdateEquip;

        /*equipmentManager = MasterSingleton.Instance.EquipmentManager;
        equipmentManager.onEquipmentChanged += UpdateEquip;*/

        playerStats.onStatsChanged += UpdateStats;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();

        UpdateUI();
        UpdateStats();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            OnToggleInventory?.Invoke();
        }
    }

    public void UpdateEquipment(EquipmentItem newItem)
    {
        equipmentSO.Equip(newItem);
        UpdateUI();
    }

    public void UpdateInventory(Item newItem)
    {
        inventorySO.Add(newItem);
        UpdateUI();
    }

    public void UpdateInvRemove(Item item)
    {
        inventorySO.Remove(item);
        UpdateUI();
    }

   // [ExposeMethodInEditor]
    public void ClearInvAndEquip()
    {
        inventorySO.ClearInventory();
        equipmentSO.ClearEquipment();
    }

    void UpdateEquip(EquipmentItem a, EquipmentItem b)
    {
        UpdateUI();
        // update equipmentSO

    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)
        {
            // might be an issue here...
            if (i < inventorySO.inventoryList.Count)
            {
                slots[i].AddItem(inventorySO.inventoryList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

/*      for (int i = 0; i < equipmentSlots.Length; i++) */       
        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        { 
            //get slot's equipment type
            EquipmentTypeSO slotType = equipmentSlot/*s[i]*/.equipmentType;

            bool slotTypeEquipped = false;

            // for each currently equipped item
            foreach (EquipmentItem currentlyEquippedItem in /*equipmentManager*/equipmentSO.currentEquipment)
            {
                Debug.Log("slot type: " + slotType.equipmentType + " currently equipped type: " 
                    + currentlyEquippedItem.equipmentTypeSO.equipmentType);

                // if it's of the same type as the current slot
                // ie, if this slot does have equipment
                if (slotType.equipmentType == currentlyEquippedItem.equipmentTypeSO.equipmentType)
                {
                    // update current slot's display and functionality with equipped item
                    equipmentSlot/*s[i]*/.AddItem(currentlyEquippedItem);
                    slotTypeEquipped = true;
                }
            }

            // if current slot doesn't have equipment
            if (!slotTypeEquipped)
            {
                equipmentSlot/*s[i]*/.ClearSlot();
            }

        }

  /*      for (int i = 0; i < equipmentSlots.Length; i++)
        {
            // maybe need to go by EquipmentType here instead of index, doesn't work with new system
            EquipmentTypeSO type = equipmentSlots[i].equipmentType;
            foreach (EquipmentItem equipment in equipmentManager.currentEquipment)
            {
                if (type = equipment.equipmentType) // if there is something of this type equipped
                {

                }
            }*/


/*                    if (equipmentManager.currentEquipment[i] != null)
            {
                equipmentSlots[i].AddItem(equipmentManager.currentEquipment[i]);
            }
            else
            {
                equipmentSlots[i].ClearSlot();
            }
        }*/
    }

    void UpdateStats()
    {
        healthText.text = "Health: " + playerStats.CurrentHealth + " / " + playerStats.maxHealth.GetValue();
        attackText.text = "Attack: " + playerStats.attack.GetValue();
        defenseText.text = "Defense: " + playerStats.defense.GetValue();
    }

    private void OnApplicationQuit()
    {
        ClearInvAndEquip();
    }
}