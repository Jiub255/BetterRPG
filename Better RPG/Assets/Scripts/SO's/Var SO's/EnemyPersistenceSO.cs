using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New EnemyPersistenceSO", menuName = "Vars/EnemyPersistenceSO")]
public class EnemyPersistenceSO : ScriptableObject
{
    public List<EnemyPersistenceData> enemyPersistenceDatas = new List<EnemyPersistenceData>();
}

[System.Serializable]
public class EnemyPersistenceData
{
    // global target object ID
    public ulong globalTargetObjectID;

    // health. if zero, deactivate object
    public int currentHealth;

    // dropLoot list. do i need new List<Item>?
    public List<Item> dropLoot = new List<Item>();

    // bool for checking if enemy just died
    public bool dead = false;
}