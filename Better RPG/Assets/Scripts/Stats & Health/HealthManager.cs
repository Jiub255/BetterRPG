using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthSO health;

    // just for testing. dont want to heal player/enemies every scene change
    private void Start()
    {
        MaxHeal();
    }

    public void TakeDamage(int amount)
    {
        health.currentHealth -= amount;

        if (health.currentHealth <= 0)
        {
            health.currentHealth = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        health.currentHealth += amount;

        if (health.currentHealth > health.maxHealth)
            health.currentHealth = health.maxHealth;
    }

    public void MaxHeal()
    {
        health.currentHealth = health.maxHealth;
    }

    // overwrite this for different enemies?
    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
        // send out a "player died" signal to UI, scene manager, whatever
    }
}