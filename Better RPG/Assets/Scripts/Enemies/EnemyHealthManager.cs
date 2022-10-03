using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealthManager : MonoBehaviour , IDamageable<int>
{
    Enemy enemy;

    public GameEventInt onExperienceGained;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(int amount)
    {
        enemy.currentHealth -= amount;

        if (enemy.currentHealth <= 0)
        {
            enemy.currentHealth = 0;
            Die();
        }
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

        DropLoot();

        Destroy(gameObject);
    }

    void DropLoot()
    {
        // do this in separate script?
    }
}