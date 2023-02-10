using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public List<ItemSO> itemsToDrop = new List<ItemSO>();

    private EnemyPersistenceData enemyPersistenceData;

    private ulong enemyGlobalTargetObjectID;

    public bool dead = false;

    // want this called after EnemyHealthManager awake,
    // so it can make a new EnemyPersistenceData if there is none yet,
    // then this check shouldn't be null ever
    private void Start()
    {
        enemyGlobalTargetObjectID = GlobalObjectId.GetGlobalObjectIdSlow(
            gameObject.transform.parent.gameObject).targetObjectId;

        enemyPersistenceData = MasterSingleton.Instance.WorldPersistenceManager.
            GetDataFromID(enemyGlobalTargetObjectID);

        // if enemy is dead, update itemsToDrop with whatever is stored in enemyPersistenceData
        if (enemyPersistenceData != null)
        {
            if (enemyPersistenceData.dead)
            {
                itemsToDrop.Clear();

                foreach (ItemSO item in enemyPersistenceData.dropLoot)
                {
                    itemsToDrop.Add(item);
                }
            }
        }
    }

    public void SetUpEnemyPersistenceDropLoot()
    {
        Debug.Log("SetUpEnemyPersistenceDropLoot called");

        if (enemyPersistenceData != null)
        {
            enemyPersistenceData.dropLoot.Clear();

            foreach (ItemSO item in itemsToDrop)
            {
                enemyPersistenceData.dropLoot.Add(item);
            }
        }
    }

    public void RemoveItemFromDropLootAndEnemyPersistenceSO(ItemSO item)
    {
        itemsToDrop.Remove(item);

        if (enemyPersistenceData != null)
        {
            enemyPersistenceData.dropLoot.Remove(item);
        }
    }
}