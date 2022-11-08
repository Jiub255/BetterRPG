using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField]
    private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField]
    private Button backButton;

    [Header("Confirmation Popup")]
    [SerializeField]
    private ConfirmationPopupMenu confirmationPopupMenu;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private string currentSceneName = "FirstScene";

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        // Disable all buttons
        DisableMenuButtons();

        // Case: loading game
        if (isLoadingGame)
        {
            currentSceneName = DataPersistenceManager.instance.ChangeSelectedProfileID(
                saveSlot.GetProfileID()).currentSceneName;

            SaveGameAndLoadScene(currentSceneName);
        }
        // Case: new game, but the save slot has data
        else if (saveSlot.hasData)
        {
            confirmationPopupMenu.ActivateMenu(
                "Starting a New Game with this slot will override the currently saved data. " +
                "Are you sure?",
                // Function to execute if we select "yes"
                () =>
                {
                    DataPersistenceManager.instance.ChangeSelectedProfileID(
                        saveSlot.GetProfileID());

                    currentSceneName = DataPersistenceManager.instance.NewGame().currentSceneName;

                    SaveGameAndLoadScene(currentSceneName);
                },
                // Function to execute if we select "cancel"
                () =>
                {
                    ActivateMenu(isLoadingGame);
                }
            );
        }
        // Case: new game, and the save slot has no data
        else
        {
            DataPersistenceManager.instance.ChangeSelectedProfileID(saveSlot.GetProfileID());

            currentSceneName = DataPersistenceManager.instance.NewGame().currentSceneName;

            SaveGameAndLoadScene(currentSceneName);
        }
    }

    private void SaveGameAndLoadScene(string sceneName)
    {
        // Don't think I want to do persistence between scenes this way
        // Using SO's and singleton Managers instead

        // Save the game anytime before loading a new scene
        //DataPersistenceManager.instance.SaveGame();

        // Load the scene
        MasterSingleton.Instance.SceneTransitionManager.ChangeScene(
            sceneName, Vector2.zero, true);
    }

    public void OnClearClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        confirmationPopupMenu.ActivateMenu(
            "Are you sure you want to delete this saved data?",
            // Function to execute if we select "yes"
            () =>
            {
                DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileID());
                ActivateMenu(isLoadingGame);
            },
            // Function to execute if we select "cancel"
            () =>
            {
                ActivateMenu(isLoadingGame);
            }
        );
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

        // Ensure that the back button is enabled when we activate the menu
        backButton.interactable = true;

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
        Button firstSelectedButton = firstSelected.GetComponent<Button>();
        SetFirstSelected(firstSelectedButton);
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