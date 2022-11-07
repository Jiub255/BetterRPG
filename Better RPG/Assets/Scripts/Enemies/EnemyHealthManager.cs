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

    [SerializeField]
    private DropLoot dropLoot;

    private ulong id;

    private EnemyPersistenceData enemyPersistenceData;

    private void Awake()
    {
        id = GlobalObjectId.GetGlobalObjectIdSlow(gameObject).targetObjectId;

        enemyPersistenceData = MasterSingleton.Instance.EnemyPersistenceManager.GetDataFromID(id);

        if (enemyPersistenceData != null)
        {
            Debug.Log("enemyPersistenceData NOT null");

            // Initialize enemy data to manager data
            currentHealth = enemyPersistenceData.currentHealth;
            if (currentHealth <= 0)
            {
                if (enemyPersistenceData.dropLoot.Count == 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    DeactivateAliveActivateDead();
                }
            }
        }
        else
        {
            Debug.Log("enemyPersistenceData null");

            // initialize manager data to enemy data
            EnemyPersistenceData blank = new EnemyPersistenceData();

            blank.globalTargetObjectID = id;
            blank.currentHealth = currentHealth;

            foreach (ItemSO item in dropLoot.itemsToDrop)
            {
                blank.dropLoot.Add(item);
            }

            enemyPersistenceData = blank;

            MasterSingleton.Instance.EnemyPersistenceManager.enemyPersistenceDatas.Add(blank);
        }
    }

    public void TakeDamage(int amount)
    {
        if (!invulnerable)
        {
            currentHealth -= amountAfterDefense(amount);
            UpdatePersistenceDataHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                UpdatePersistenceDataHealth(currentHealth);
                Die();
            }
        }
    }

    private void UpdatePersistenceDataHealth(int newCurrentHealth)
    {
        enemyPersistenceData.currentHealth = newCurrentHealth;
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
        UpdatePersistenceDataHealth(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            UpdatePersistenceDataHealth(currentHealth);
        }
    }

    public void MaxHeal()
    {
        currentHealth = maxHealth;
        UpdatePersistenceDataHealth(currentHealth);
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

        enemyPersistenceData.dead = true;

        Destroy(transform.GetComponent<EnemyHealthManager>());
    }
}