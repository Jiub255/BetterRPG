using UnityEngine;
using UnityEngine.UI;

public class LootMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject lootMenuPanel;

    [SerializeField]
    private Transform itemsParent;

    private LootSlot[] slots;

    public Button nextDropLootButton;
    public Button previousDropLootButton;

    // change this when changing DropLoot
    public Text currentLootEnemyText;

    private PlayerLootManager playerLootManager;

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<LootSlot>();
    }

    // listens for on Player instantiated
    public void GetPlayerReference(Transform playerTransform)
    {
        playerLootManager = playerTransform.GetComponentInChildren<PlayerLootManager>();
    }

    // go to next or previous DropLoot in PlayerLootManager
    public void ChangeDropLoot(int indexChange)
    {
        playerLootManager.ChangeCurrentDropLootIndex(indexChange);
    }

    // listens for onChangeDropLoot from PlayerLootMenu
    public void UpdateUI(DropLoot dropLoot)
    {
        if (dropLoot == null)
        {
            ChangeLootEnemyText("None");

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].ClearSlot();
            }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                ChangeLootEnemyText(dropLoot.transform.parent.gameObject.name);

                if ( i < dropLoot.itemsToDrop.Count)
                {
                    slots[i].AddItem(dropLoot.itemsToDrop[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
        }

        if (playerLootManager.dropLoots.Count <= 1)
        {
            nextDropLootButton.gameObject.SetActive(false);
            previousDropLootButton.gameObject.SetActive(false);
        }  
        if (playerLootManager.dropLoots.Count > 1)
        {
            nextDropLootButton.gameObject.SetActive(true);
            previousDropLootButton.gameObject.SetActive(true);
        }
    }

    private void ChangeLootEnemyText(string newName)
    {
        currentLootEnemyText.text = newName;
    }

    // listens for onOpenLootMenu
    public void OpenLootUI()
    {
        if (!lootMenuPanel.activeInHierarchy)
            lootMenuPanel.SetActive(true);
    }

    // listens for onCloseLootMenu
    public void CloseLootUI()
    {
        if (lootMenuPanel.activeInHierarchy)
            lootMenuPanel.SetActive(false);
    }
}