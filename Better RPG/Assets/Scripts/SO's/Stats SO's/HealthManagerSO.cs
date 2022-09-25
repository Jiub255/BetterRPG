using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Manager SO", menuName = "Stats/Health Manager")]
public class HealthManagerSO : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;

    void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // send out a "player died" signal to UI, scene manager, whatever
    }
}