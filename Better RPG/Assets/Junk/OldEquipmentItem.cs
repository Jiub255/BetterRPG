using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldEquipmentItem : Item
{
    private StatModifier flat;
    private StatModifier percent;

    public void Equip(PlayerStatManager playerStatManager)
    {
        playerStatManager.Strength.AddModifier(new StatModifier(10, StatModType.Flat, this));

        playerStatManager.Strength.AddModifier(new StatModifier(0.1f, StatModType.PercentAdd, this));
    }
}