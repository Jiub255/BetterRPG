using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat maxHealth;
    public int CurrentHealth { get; private set; }

    public Stat maxMagic;
    public int CurrentMagic { get; private set; }

    public Stat attack;
    public Stat defense;

    private void Awake()
    {
        CurrentHealth = maxHealth.GetValue();
    }

    public void ChangeStat(Stat stat, int amount)
    {
        stat.ChangeBaseValue(amount);
    }

    public void TakeDamage(int damage)
    {
        damage -= defense.GetValue();

        if (damage <= 0)
            damage = 0;

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // maybe too general? could just have a separate heal method
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            amount += defense.GetValue();
            if (amount > 0)
                amount = 0;
        }

        CurrentHealth += amount;

        if (CurrentHealth > maxHealth.GetValue())
            CurrentHealth = maxHealth.GetValue();

        if (CurrentHealth <= 0)
            Die();
    }

    public bool ChangeMagic(int amount)
    {
        if (-amount > CurrentMagic)
        {
            Debug.Log("Not enough magic");
            return false;
        } 

        CurrentMagic += amount;
        return true;
    }

    public virtual void Die()
    {
        // die in some way
        // this method is meant to be overwritten
        Debug.Log(transform.name + " died");
    }
}