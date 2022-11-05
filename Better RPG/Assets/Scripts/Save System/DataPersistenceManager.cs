using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileID = "";

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DataPersistenceManager in the scene.");
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();

        selectedProfileID = dataHandler.GetMostRecentlyUpdatedProfileID();
    }

    private void Start()
    {
        //dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        //dataPersistenceObjects = FindAllDataPersistenceObjects();

        Debug.Log(dataPersistenceObjects.Count.ToString());
    }

    public void NewGame()
    {
        gameData = new GameData();

        // Push the loaded data to all other scripts that need it.
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler.
        gameData = dataHandler.Load(selectedProfileID);

        // If no data can be loaded, warn player.
        if (gameData == null)
        {
            Debug.Log("No data was found. Start a new game.");
            return;
        }

        // Push the loaded data to all other scripts that need it.
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }

        Debug.Log("Loaded current health = " + gameData.currentHealth);
    }

    public void SaveGame()
    {
        // If no data can be saved, warn player.
        if (gameData == null)
        {
            Debug.Log("No data was found. Start a new game.");
            return;
        }

        // Pass the data to other scripts so they can update it.
        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(ref gameData);
        }

        // Timestamp the data so we know when it was last saved
        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        Debug.Log("Saved current health = " + gameData.currentHealth);

        // Save that data to a file using the data handler.
        dataHandler.Save(gameData, selectedProfileID);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void ChangeSelectedProfileID(string newProfileID)
    {
        // Update the profile to use for saving and loading
        selectedProfileID = newProfileID;
        // Load the game, which will use that profile, updating our game data accordingly
        LoadGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = 
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        gameData = dataHandler.Load(selectedProfileID);

        Debug.Log("Save data exists: " + (gameData != null).ToString());

        return (gameData != null);
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}