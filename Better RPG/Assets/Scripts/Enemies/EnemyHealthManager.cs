using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(DropLoot))]
public class EnemyHealthManager : MonoBehaviour , IDamageable<int>
{
    Enemy enemy;

    public GameEventInt onExperienceGained;

    public GameObject deathAnimation;

    DropLoot dropLoot;

    public bool invulnerable = false;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        dropLoot = GetComponent<DropLoot>();
    }

    public void TakeDamage(int amount)
    {
        if (!invulnerable)
        {
            enemy.currentHealth -= amountAfterDefense(amount);

            if (enemy.currentHealth <= 0)
            {
                enemy.currentHealth = 0;
                Die();
            }
        }
    }

    int amountAfterDefense(int amount)
    {
        amount -= enemy.defense;
        if (amount <= 0)
            return 0;
        return amount;
    }

    public void Heal(int amount)
    {
        enemy.currentHealth += amount;

        if (enemy.currentHealth > enemy.maxHealth)
            enemy.currentHealth = enemy.maxHealth;
    }

    public void MaxHeal()
    {
        enemy.currentHealth = enemy.maxHealth;
    }

    public void Die()
    {
        Debug.Log(transform.name + " died");

        onExperienceGained.Raise(enemy.experience);

        dropLoot.DropItems();

        // should i destroy/deactivate this when its done playing?
        GameObject deathExplosionInstance = Instantiate(deathAnimation, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}