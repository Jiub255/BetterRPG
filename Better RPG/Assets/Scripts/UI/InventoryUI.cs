using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventorySO;

    // inv slot prefab
    [SerializeField]
    private GameObject inventorySlot;

    [SerializeField]
    private Transform inventoryContent;

    private ObjectPool objectPool;

    private void Start()
    {
        UpdateUI();
        UpdateUI();
    }

    public void GetPlayerReference(Transform playerTransform)
    {
        objectPool = playerTransform.GetComponent<ObjectPool>();
    }

    public void UpdateUI()
    {
        foreach (Transform child in inventoryContent)
        {
            child.GetComponent<InventorySlot>().ClearSlot();
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < inventorySO.inventoryWithAmountsList.Count; i++)
        {
            GameObject slot = objectPool.GetPooledObject("Inventory Slot");
            if (slot != null)
            {
                slot.SetActive(true);
                slot.transform.SetParent(inventoryContent.transform, false);
            }

            slot.GetComponent<InventorySlot>().AddItem(inventorySO.inventoryWithAmountsList[i]);
        }
    }
}