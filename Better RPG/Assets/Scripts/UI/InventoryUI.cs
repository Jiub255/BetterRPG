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
    EquipSlot[] equipmentSlots;

    public static event Action OnToggleInventory;

    void Start()
    {
        inventory = MasterSingleton.Instance.Inventory;
        inventory.onItemChangedCallback += UpdateUI;

        equipmentManager = MasterSingleton.Instance.EquipmentManager;
        equipmentManager.onEquipmentChanged += UpdateEquip;

        playerStats.onStatsChanged += UpdateStats;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipSlot>();

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

    void UpdateEquip(Equipment a, Equipment b)
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentManager.currentEquipment[i] != null)
            {
                equipmentSlots[i].AddItem(equipmentManager.currentEquipment[i]);
            }
            else
            {
                equipmentSlots[i].ClearSlot();
            }
        }
    }

    void UpdateStats()
    {
        healthText.text = "Health: " + playerStats.CurrentHealth + " / " + playerStats.maxHealth.GetValue();
        attackText.text = "Attack: " + playerStats.attack.GetValue();
        defenseText.text = "Defense: " + playerStats.defense.GetValue();
    }
}