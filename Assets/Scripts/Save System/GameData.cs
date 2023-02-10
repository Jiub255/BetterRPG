using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    // To store time/date of save, for finding most recent save for continue button
    public long lastUpdated;

    // From PlayerHealthManager
    public int maxHealth;
    public int currentHealth;

    // From PlayerMagicManager
    public int maxMagic;
    public int currentMagic;

    // From EnemyPersistenceManager
    public List<EnemyPersistenceData> enemyPersistenceDatas;

    // From InventoryManager
    public List<ItemAmount> inventoryList;

    // From EquipmentManager
    public List<EquipmentItem> currentEquipment;

    // From StatManager
    public int attackBaseValue;
    public int defenseBaseValue;
    public float knockbackForceBaseValue;
    public float knockbackDurationBaseValue;
    public int skillPoints;

    // From ExperienceManager
    public int experience;
    public int level;

    // From PlayerMovement
    public float playerXPosition;
    public float playerYPosition;
    public bool canMove;
    public string currentSceneName = "FirstScene";

    // Put new game initialization values in here
    public GameData()
    {
        // Health
        maxHealth = 10;
        currentHealth = 10;
        // Magic
        maxMagic = 10;
        currentMagic = 10;
        // Enemy Persistence Data
        enemyPersistenceDatas = new List<EnemyPersistenceData>();
        // Inventory
        inventoryList = new List<ItemAmount>();
        // Equipment
        currentEquipment = new List<EquipmentItem>();
        // Stats (just placeholder default values for now, balance them later)
        attackBaseValue = 1;
        defenseBaseValue = 1;
        knockbackForceBaseValue = 0f;
        knockbackDurationBaseValue = 0f;
        skillPoints = 0;
        // Experience and Level
        experience = 0;
        level = 1;
        // Player Movement/Position
        playerXPosition = 0f;
        playerYPosition = 0f;
        canMove = true;
        currentSceneName = "FirstScene";
    }

    // Do an actual calculation here eventually
    public int GetPercentageComplete()
    {
        return 5;
    }
}