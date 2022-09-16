using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int CalculateExperience()
    {
        // or whatever formula, this is just to start
        int exp = attack.GetValue() * defense.GetValue();

        return exp;
    }

    public override void Die()
    {
        base.Die();

        MasterSingleton.Instance.Player.GetComponent<PlayerStats>().GainExperience(CalculateExperience());
       
        //death animation
        //death sounds
        //drop loot?

        Destroy(gameObject);
    }
} 