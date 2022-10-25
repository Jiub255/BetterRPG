using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform itemsParent;

    private InventorySlot[] slots;

    [SerializeField]
    private InventorySO inventorySO;

    // infinite inv stuff

    // inv slot prefab
    [SerializeField]
    private GameObject inventorySlot;

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

    // could this be done with object pooling instead of instantiate/destroy?
/*    public void UpdateUI2()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child);
        }

        for (int i = 0; i < inventorySO.inventoryList.Count; i++)
        {
            GameObject slot = Instantiate(inventorySlot, itemsParent);
            slot.GetComponent<InventorySlot>().AddItem(inventorySO.inventoryList[i]);
        }
    }*/
}