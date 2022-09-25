using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthSO health;

    void ChangeHealth(int amount)
    {
        health.currentHealth += amount;

        if (health.currentHealth > health.maxHealth)
            health.currentHealth = health.maxHealth;

        if (health.currentHealth <= 0)
        {
            health.currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // send out a "player died" signal to UI, scene manager, whatever
    }
}