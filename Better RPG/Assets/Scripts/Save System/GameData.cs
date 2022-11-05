[System.Serializable]
public class GameData
{
    // Getting from playerHealthSO.
    public int currentHealth; 

    // Put new game initialization values in here
    public GameData()
    {
        this.currentHealth = 1;
    }
}