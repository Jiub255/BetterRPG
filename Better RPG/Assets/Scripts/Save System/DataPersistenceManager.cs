using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    [Header("Auto Saving Configuration")]
    [SerializeField]
    private float autoSaveTimeSeconds = 60f;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileID = "";

    private Coroutine autoSaveCoroutine;

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

        InitializeSelectedProfileID();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        Debug.Log(dataPersistenceObjects.Count.ToString());

        // Start up the autosave coroutine
        if (autoSaveCoroutine != null)
        {
            StopCoroutine(autoSaveCoroutine);
        }
        autoSaveCoroutine = StartCoroutine(AutoSave());

        // Don't think I want to do persistence between scenes this way
        // Using SO's instead
        // LoadGame();
    }

    public void DeleteProfileData(string profileID)
    {
        // Delete the data for this profile ID
        dataHandler.Delete(profileID);
        // Initialize the selected profile ID
        InitializeSelectedProfileID();
        // Reload the game so that our data matches the newly selected profile ID
        LoadGame();
    }

    private void InitializeSelectedProfileID()
    {
        selectedProfileID = dataHandler.GetMostRecentlyUpdatedProfileID();
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
            dataPersistenceObject.SaveData(gameData);
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

    public void ChangeSelectedProfileID(string newProfileID)
    {
        // Update the profile to use for saving and loading
        selectedProfileID = newProfileID;
        // Load the game, which will use that profile, updating our game data accordingly
        LoadGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // FindObjectsOfType takes in an optional boolean to include inactive gameobjects
        IEnumerable<IDataPersistence> dataPersistenceObjects = 
            FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

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

    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveTimeSeconds);
            SaveGame();
            Debug.Log("Auto Saved Game");
        }
    }
}