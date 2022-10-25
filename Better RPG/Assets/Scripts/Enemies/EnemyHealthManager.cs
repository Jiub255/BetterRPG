using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour , IDamageable<int>, IHealable<int>
{
    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth = 1;
    [SerializeField]
    private int defense = 1;
    [SerializeField]
    private int experience = 1;

    public GameEventInt onExperienceGained;

    public GameObject deathAnimation;

    public bool invulnerable = false;

    // enemy health persistence
    [SerializeField]
    private EnemyPersistenceSO enemyPersistenceSO;

    [SerializeField]
    private DropLoot dropLoot;

    private ulong id;

    private void Awake()
    {
        id = GlobalObjectId.GetGlobalObjectIdSlow(this.gameObject).targetObjectId;

        bool onList = false;

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            // if the ID is on the list, set health to the int value stored on the SO
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID == id)
            {
                onList = true;
                currentHealth = enemyPersistenceSO.enemyPersistenceDatas[i].currentHealth;
                if (currentHealth <= 0)
                {
                    if (enemyPersistenceSO.enemyPersistenceDatas[i].dropLoot.Count == 0)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        DeactivateAliveActivateDead();
                    }
                }
            }
        }

        if (onList == false)
        {
            EnemyPersistenceData blank = new EnemyPersistenceData();

            blank.globalTargetObjectID = id;
            blank.currentHealth = currentHealth;

            enemyPersistenceSO.enemyPersistenceDatas.Add(blank);
        }
    }

    public void TakeDamage(int amount)
    {
        if (!invulnerable)
        {
            currentHealth -= amountAfterDefense(amount);
            UpdateULongIntList(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                UpdateULongIntList(currentHealth);
                Die();
            }
        }
    }

    private void UpdateULongIntList(int newCurrentHealth)
    {
        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            // if the ID is on the list, set health to the int value stored on the SO
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID == id)
            {
                enemyPersistenceSO.enemyPersistenceDatas[i].currentHealth = newCurrentHealth;
            }
        }
    }

    int amountAfterDefense(int amount)
    {
        amount -= defense;
        if (amount <= 0)
            return 0;
        return amount;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        UpdateULongIntList(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            UpdateULongIntList(currentHealth);
        }
    }

    public void MaxHeal()
    {
        currentHealth = maxHealth;
        UpdateULongIntList(currentHealth);
    }

    public void Die()
    {
        Debug.Log(transform.name + " died");

        onExperienceGained.Raise(experience);

        // should i destroy/deactivate this when its done playing?
        GameObject deathExplosionInstance = Instantiate(deathAnimation, transform.position, Quaternion.identity);

        // deactivate alive, activate dead
        DeactivateAliveActivateDead();
    }

    private void DeactivateAliveActivateDead()
    {
        //awake gets called here, before changing the bool
        transform.GetChild(1).gameObject.SetActive(true);

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<EnemyMoveChaseWander>().enabled = false;
        transform.GetComponent<Rigidbody2D>().isKinematic = true;
        transform.GetComponent<Collider2D>().enabled = false;

        dropLoot.SetUpEnemyPersistenceDropLoot();

        StartCoroutine(WaitOneFrameThenChangeBoolAndDeactivate());
    }

    IEnumerator WaitOneFrameThenChangeBoolAndDeactivate()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < enemyPersistenceSO.enemyPersistenceDatas.Count; i++)
        {
            // if the ID is on the list
            if (enemyPersistenceSO.enemyPersistenceDatas[i].globalTargetObjectID == id)
            {
                enemyPersistenceSO.enemyPersistenceDatas[i].dead = true;
            }
        }
        Destroy(transform.GetComponent<EnemyHealthManager>());
    }
}