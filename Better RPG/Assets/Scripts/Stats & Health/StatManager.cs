using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public StatSO attack;
    public StatSO defense;

    public GameEvent onStatsChanged;

    void ChangeStat(StatSO stat, int amount)
    {
        stat.ChangeBaseValue(amount);
    }

    public void AddModifiers(EquipmentItem newItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
            onStatsChanged.Raise();
        }
    }

    public void RemoveModifiers(EquipmentItem oldItem)
    {
        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
            onStatsChanged.Raise();
        }
    }
}