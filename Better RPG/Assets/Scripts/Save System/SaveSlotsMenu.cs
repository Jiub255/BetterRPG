using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField]
    private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField]
    private Button backButton;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        // Disable all buttons
        DisableMenuButtons();

        // Update the selected profile ID to be used for data persistence
        DataPersistenceManager.instance.ChangeSelectedProfileID(saveSlot.GetProfileID());

        if (!isLoadingGame)
        {
            // Create a new game, which will initialize our data to a clean slate
            DataPersistenceManager.instance.NewGame();
        }

        // Load the scene, which will in turn save the game because of 
        // OnSceneUnloaded() in the DataPersistenceManager
        // Could load whichever scene the last save was in, instead of always FirstScene
        MasterSingleton.Instance.SceneTransitionManager.ChangeScene("FirstScene", Vector2.zero);
        //SceneManager.LoadSceneAsync("FirstScene");

    }

    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        // Set this menu to be active
        gameObject.SetActive(true);

        // Set mode
        this.isLoadingGame = isLoadingGame;

        // Load all of the profiles that exist
        Dictionary<string, GameData> profilesGameData = 
            DataPersistenceManager.instance.GetAllProfilesGameData();

        // Loop through each save slot and set the content appropriately
        GameObject firstSelected = backButton.gameObject;
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
                if (firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected = saveSlot.gameObject;
                }
            }
        }

        // Set the first selected button
        StartCoroutine(SetFirstSelected(firstSelected));
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }

        backButton.interactable = false;
    }
}