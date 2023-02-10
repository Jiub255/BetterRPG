using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton Instance { get; private set; }

    public AudioManager AudioManager { get; private set; }
    public EquipmentManager EquipmentManager { get; private set; }
    public InputManager InputManager { get; private set; }
    public SceneMusic SceneMusic { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    public SceneTransitionManager SceneTransitionManager { get; private set; }
    public WorldPersistenceManager WorldPersistenceManager { get; private set; }

    public GameObject Canvas { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Found more than one MasterSingleton in the scene.");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        AudioManager = GetComponentInChildren<AudioManager>();
        Canvas = GetComponentInChildren<Canvas>().gameObject;
        EquipmentManager = GetComponentInChildren<EquipmentManager>();
        InputManager = GetComponentInChildren<InputManager>();
        SceneMusic = GetComponentInChildren<SceneMusic>();
        ObjectPool = GetComponentInChildren<ObjectPool>();
        SceneTransitionManager = GetComponentInChildren<SceneTransitionManager>();
        WorldPersistenceManager = GetComponentInChildren<WorldPersistenceManager>();

        DontDestroyOnLoad(gameObject);
    }
}