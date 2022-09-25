using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public PlayerStats playerStats;

    public int CalculateExperience()
    {
        // or whatever formula, this is just to start
        int exp = attack.GetValue() * defense.GetValue();

        return exp;
    }

    public override void Die()
    {
        base.Die();

        // get reference in better way? use signal?
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        playerStats.GainExperience(CalculateExperience());
        //MasterSingleton.Instance.Player.GetComponent<PlayerStats>().GainExperience(CalculateExperience());
       
        //death animation
        //death sounds
        //drop loot?

        Destroy(gameObject);
    }
} 