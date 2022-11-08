using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPanel;

    [SerializeField]
    private InventorySO playerInventorySO;
    private InventorySO shopInventorySO;

    [SerializeField]
    private GameEvent onDialogueOver;

    [SerializeField]
    private Transform playerInventoryContent;
    [SerializeField]
    private Transform shopInventoryContent;

    private void OnEnable()
    {
        ShopInventoryManager.OnShopChanged += UpdateShopUI;
        NPCDialogueServices.OnTalkedToMerchant += GetShopInvSOReference;
    }

    private void OnDisable()
    {
        ShopInventoryManager.OnShopChanged -= UpdateShopUI;
        NPCDialogueServices.OnTalkedToMerchant -= GetShopInvSOReference;
    }

    private void GetShopInvSOReference(InventorySO shopInventorySO)
    {
        this.shopInventorySO = shopInventorySO;
    }

    public void OpenShopUI()
    {
        shopPanel.SetActive(true);
        UpdateShopUI(shopInventorySO);
    }

    public void CloseShopUI()
    {
        shopPanel.SetActive(false);
        onDialogueOver.Raise();
        // still need to reenable HUD and get player controls set right
        // can't talk to NPC again after this 
        // Use action maps
    }

    // Listens for onShopChanged gameEventInventorySO?
    public void UpdateShopUI(InventorySO shopInventorySO)
    {
        // Player Inventory
        foreach (Transform child in playerInventoryContent)
        {
            child.GetComponent<InventorySlot>().ClearSlot();
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < playerInventorySO.inventoryWithAmountsList.Count; i++)
        {
            GameObject slot = MasterSingleton.Instance.ObjectPool.GetPooledObject("Inventory Slot");
            if (slot != null)
            {
                slot.SetActive(true);
                slot.transform.SetParent(playerInventoryContent.transform, false);
            }

            slot.GetComponent<InventorySlot>().AddItem(playerInventorySO.inventoryWithAmountsList[i]);
        }

        // Shop Inventory
        foreach (Transform child in shopInventoryContent)
        {
            child.GetComponent<InventorySlot>().ClearSlot();
            child.gameObject.SetActive(false);
        }

        for (int i = 0; i < shopInventorySO.inventoryWithAmountsList.Count; i++)
        {
            GameObject slot = MasterSingleton.Instance.ObjectPool.GetPooledObject("Inventory Slot");
            if (slot != null)
            {
                slot.SetActive(true);
                slot.transform.SetParent(shopInventoryContent.transform, false);
            }

            slot.GetComponent<InventorySlot>().AddItem(shopInventorySO.inventoryWithAmountsList[i]);
        }
    }
}