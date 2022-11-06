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

[System.Serializable]
public class EnemyPersistenceData
{
    // global target object ID
    public ulong globalTargetObjectID;

    // health. if zero, deactivate object
    public int currentHealth;

    // dropLoot list. do i need new List<Item>?
    public List<ItemSO> dropLoot = new List<ItemSO>();

    // bool for checking if enemy just died
    public bool dead = false;
}