using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPersistenceManager : MonoBehaviour, IDataPersistence
{
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
            enemyPersistenceDatas.Add(enemyPersistenceData);
        }

        // Push this data to all EnemyHealthManagers and DropLoots?
        // Maybe use a general signal OnLoadData and have all relevant things listen?
        // Or will the awake/start methods on those classes fill them up themselves?
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