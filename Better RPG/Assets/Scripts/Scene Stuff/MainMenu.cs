using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("Menu Navigation")]
    [SerializeField]
    private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button loadGameButton;

    private void Start()
    {
        // Works sometimes, sometimes not. How?
        if (!DataPersistenceManager.instance.HasGameData())
        {
            Debug.Log("No Saved Game Data");

            continueButton.interactable = false;
            loadGameButton.interactable = false;
        }    
    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        DeactivateMenu();

/*        DisableAllButtons();

        // Initialize Player/SO's
        // Do I need to initialize the scene after it's loaded too?
        // Can't do it from here since ChangeScene unloads this scene which destroys this script
        DataPersistenceManager.instance.NewGame(); // ??

        // Set HUD to active
        MasterSingleton.Instance.Canvas.transform.GetChild(5).gameObject.SetActive(true);

        // Load FirstScene
        MasterSingleton.Instance.SceneTransitionManager.ChangeScene("FirstScene", Vector2.zero);
*/
        #region Notes on loading
        // Load FirstScene async

        // Use SceneChangeManager singleton? Or SceneTransition script?

        // Wait until loaded

        // Set new scene as active
        // Is this necessary? Not instantiating anything, at least not yet

        // Initialize Player/Scene for new game

        // Unload this scene
        #endregion
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        DeactivateMenu();
    }

    public void OnContinueClicked()
    {
        DisableAllButtons();

        // Initialize Player/SO's
        // Do I need to initialize the scene after it's loaded too?
        // Can't do it from here since ChangeScene unloads this scene which destroys this script
        DataPersistenceManager.instance.LoadGame(); // ??

        // Set HUD to active
        MasterSingleton.Instance.Canvas.transform.GetChild(5).gameObject.SetActive(true);

        // Load FirstScene
        MasterSingleton.Instance.SceneTransitionManager.ChangeScene("FirstScene", Vector2.zero);
    }

    private void DisableAllButtons()
    {
        newGameButton.interactable = false;
        continueButton.interactable = false;
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}