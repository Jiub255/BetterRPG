using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public List<ItemSO> itemsToDrop = new List<ItemSO>();

    // enemy persistence data
    private ulong enemyGlobalTargetObjectID;

    [SerializeField]
    private EnemyPersistenceSO enemyPersistenceSO;

    public bool dead = false;

    private void Awake()
    {
        Debug.Log("DropLoot awake");

        enemyGlobalTargetObjectID = GlobalObjectId.GetGlobalObjectIdSlow(
            this.gameObject.transform.parent.gameObject).targetObjectId;

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID ==
                enemyGlobalTargetObjectID)
            {
                // don't want to call this if enemy just died
                if (enemyPersistenceSO.enemyPersistenceDatas[i].dead)
                {
                    Debug.Log("dead");

                    itemsToDrop.Clear();

                    foreach (ItemSO item in enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot)
                    {
                        itemsToDrop.Add(item);
                    }
                }
            }
        }
    }

    public void SetUpEnemyPersistenceDropLoot()
    {
        Debug.Log("SetUpEnemyPersistenceDropLoot called");

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID ==
            enemyGlobalTargetObjectID)
            {
                enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot.Clear();

                foreach (ItemSO item in itemsToDrop)
                {
                    enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot.Add(item);
                }
            }
        }
    }

/*    public void AddItemToEnemyPersistenceSO(Item item)
    {
        //itemsToDrop.Add(item);

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID ==
                enemyGlobalTargetObjectID)
            {
                enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot.Add(item);
            }
        }
    }*/

    public void RemoveItemFromDropLootAndEnemyPersistenceSO(ItemSO item)
    {
        itemsToDrop.Remove(item);

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID ==
                enemyGlobalTargetObjectID)
            {
                enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot.Remove(item);
            }
        }
    }
}