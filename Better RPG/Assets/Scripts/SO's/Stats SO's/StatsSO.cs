using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats SO", menuName = "Stats/Stats")]
public class StatsSO : ScriptableObject
{
    public Stat attack;
    public Stat defense;

    public EquipmentSO equipmentSO;

    public void ChangeStat(Stat stat, int amount)
    {
        stat.ChangeBaseValue(amount);
    }

    void OnEquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
          //  onStatsChanged?.Invoke();
        }

        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
          //  onStatsChanged?.Invoke();
        }
    }
}