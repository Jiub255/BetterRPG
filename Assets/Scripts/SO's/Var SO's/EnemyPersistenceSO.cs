using System.Collections.Generic;
using UnityEngine;

// Make this a singleton monobehaviour for easy saving/loading?
[System.Serializable]
[CreateAssetMenu(fileName = "New EnemyPersistenceSO", menuName = "Vars/EnemyPersistenceSO")]
public class EnemyPersistenceSO : ScriptableObject
{
    public List<EnemyPersistenceData> enemyPersistenceDatas = new List<EnemyPersistenceData>();

    public void ClearPersistenceData()
    {
        enemyPersistenceDatas.Clear();
    }
}