using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform itemsParent;

    private InventorySlot[] slots;

    [SerializeField]
    private InventorySO inventorySO;

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventorySO.inventoryList.Count)
            {
                slots[i].AddItem(inventorySO.inventoryList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}