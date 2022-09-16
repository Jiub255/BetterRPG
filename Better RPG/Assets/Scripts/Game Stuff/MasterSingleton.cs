using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton Instance { get; private set; }

    public GameManager GameManager { get; private set; }
    public Inventory Inventory { get; private set; }
    public EquipmentManager EquipmentManager { get; private set; }
    public PlayerManager PlayerManager { get; private set; }
    public InventoryUI InventoryUI { get; private set; }

    public GameObject GameManagerObject;
    public GameObject Canvas;
    public GameObject Player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameManager = GetComponentInChildren<GameManager>();
        Inventory = GetComponentInChildren<Inventory>();
        EquipmentManager = GetComponentInChildren<EquipmentManager>();
        PlayerManager = GetComponentInChildren<PlayerManager>();
        InventoryUI = GetComponentInChildren<InventoryUI>();

        GameManagerObject = transform.GetChild(0).gameObject;
        Canvas = transform.GetChild(1).gameObject;
        Player = transform.GetChild(2).gameObject;

        // necessary?
        DontDestroyOnLoad(this.gameObject);
    }
}