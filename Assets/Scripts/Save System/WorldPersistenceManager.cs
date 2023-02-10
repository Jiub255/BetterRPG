using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldPersistenceManager : MonoBehaviour, IDataPersistence
{
    // Add other lists for items picked up, objects broken, etc...
    // Make new custom classes for holding their IDs and necessary data
    public List<EnemyPersistenceData> enemyPersistenceDatas = new List<EnemyPersistenceData>();

    public void ClearPersistenceData()
    {
        enemyPersistenceDatas.Clear();
    }

    public EnemyPersistenceData GetDataFromID(ulong ID)
    {
        foreach (EnemyPersistenceData enemyPersistenceData in enemyPersistenceDatas)
        {
            if (enemyPersistenceData.globalTargetObjectID == ID)
            {
                return enemyPersistenceData;
            }
        }
        return null;
    }

    public void LoadData(GameData data)
    {
        enemyPersistenceDatas.Clear();

        foreach (EnemyPersistenceData enemyPersistenceData in data.enemyPersistenceDatas)
        {
            // will this link the dropLoot lists like when you copy a list?
            // Doesn't seem to, should be fine
            enemyPersistenceDatas.Add(enemyPersistenceData);
        }

        // Push this data to all EnemyHealthManagers and DropLoots?
        // Maybe use a general signal OnLoadData and have all relevant things listen?
        // Or will the awake/start methods on those classes fill them up themselves?
            // This seems to be happening just fine. Might need signals for other things though
    }

    public void SaveData(GameData data)
    {
        data.enemyPersistenceDatas.Clear();

        foreach (EnemyPersistenceData enemyPersistenceData in enemyPersistenceDatas)
        {
            data.enemyPersistenceDatas.Add(enemyPersistenceData);
        }
    }
}