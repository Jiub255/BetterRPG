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

    public void TakeDamage(int amount)
    {
        if (!invulnerable)
        {
            currentHealth -= amountAfterDefense(amount);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
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

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void MaxHeal()
    {
        currentHealth = maxHealth;
    }

    public void Die()
    {
        Debug.Log(transform.name + " died");

        onExperienceGained.Raise(experience);

        // should i destroy/deactivate this when its done playing?
        GameObject deathExplosionInstance = Instantiate(deathAnimation, transform.position, Quaternion.identity);

        // deactivate alive, activate dead
        transform.GetChild(1).gameObject.SetActive(true);
/*        foreach (Collider2D collider2D in transform.GetChild(0).GetComponents<Collider2D>())
        {
            collider2D.enabled = false;
        }*/
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<EnemyMoveChaseWander>().enabled = false;
        transform.GetComponent<Rigidbody2D>().isKinematic = true;
    }
}