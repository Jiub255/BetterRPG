[System.Serializable]
public class GameData
{
    // To store time/date of save, for finding most recent save for continue button
    public long lastUpdated;

    // Getting from playerHealthSO.
    public int currentHealth; 

    // Put new game initialization values in here
    public GameData()
    {
        this.currentHealth = 1;
    }

    public int GetPercentageComplete()
    {
        // Do an actual calculation here eventually
        return 5;
    }
}