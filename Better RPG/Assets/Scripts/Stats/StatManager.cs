using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public StatSO attack;
    public StatSO defense;

    void ChangeStat(Stat stat, int amount)
    {
        stat.ChangeBaseValue(amount);
    }

    // Have a couple GameEventListenerEquipmentItems as components on the player object, along with this script
    /*    void OnEquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem)
        {
            if (newItem != null)
            {
                defense.AddModifier(newItem.armorModifier);
                attack.AddModifier(newItem.damageModifier);
            }

            if (oldItem != null)
            {
                defense.RemoveModifier(oldItem.armorModifier);
                attack.RemoveModifier(oldItem.damageModifier);
            }
        }*/

    public void AddModifiers(EquipmentItem newItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
        }
    }

    public void RemoveModifiers(EquipmentItem oldItem)
    {
        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
        }
    }
}