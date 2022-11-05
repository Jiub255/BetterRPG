using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

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
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();

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
        gameData = dataHandler.Load();

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

        Debug.Log("Saved current health = " + gameData.currentHealth);

        // Save that data to a file using the data handler.
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = 
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        gameData = dataHandler.Load();

        Debug.Log("Save data exists: " + (gameData != null).ToString());

        return (gameData != null);
    }
}