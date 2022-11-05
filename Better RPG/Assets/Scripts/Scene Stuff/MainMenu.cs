using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button loadGameButton;

    private void Start()
    {
        // Works sometimes, sometimes not. How?
        if (!DataPersistenceManager.instance.HasGameData())
        {
            Debug.Log("No Saved Game Data");

            loadGameButton.interactable = false;
        }    
    }

    public void OnNewGameClicked()
    {
        DisableAllButtons();

        // Initialize Player/SO's
        // Do I need to initialize the scene after it's loaded too?
        // Can't do it from here since ChangeScene unloads this scene which destroys this script
        DataPersistenceManager.instance.NewGame(); // ??

        // Set HUD to active
        MasterSingleton.Instance.Canvas.transform.GetChild(5).gameObject.SetActive(true);

        // Load FirstScene
        MasterSingleton.Instance.SceneTransitionManager.ChangeScene("FirstScene", Vector2.zero);
        
        // Load FirstScene async

        // Use SceneChangeManager singleton? Or SceneTransition script?

        // Wait until loaded

        // Set new scene as active
        // Is this necessary? Not instantiating anything, at least not yet

        // Initialize Player/Scene for new game

        // Unload this scene

    }

    public void OnLoadGameClicked()
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

        // Load whichever scene you saved in async
        // Use SceneChangeManager singleton? Or SceneTransition script?

        // Wait until loaded

        // Set new scene as active
        // Is this necessary? Not instantiating anything, at least not yet

        // Load gameData 

        // Initialize Player/Scene from loaded gameData

        // Unload this scene

    }

    private void DisableAllButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }
}