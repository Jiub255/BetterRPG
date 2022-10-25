using System;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public StatSO attack;
    public StatSO defense;

    // these should come from the weapon's stats
    public StatFloatSO knockbackForce;
    public StatFloatSO knockbackDuration;

    public GameEvent onStatsChanged;

    public EquipmentSO equipmentSO;

    public int skillPoints = 0;

    public static event Action<bool> onSpentLastSkillPoint;

    private void Awake()
    {
        CalculateMods(); 
    }

    private void OnEnable()
    {
        StatsUI.onRaiseStat += RaiseStat;
    }

    private void OnDisable()
    {
        StatsUI.onRaiseStat -= RaiseStat;
    }

    public void RaiseStat(StatSO stat)
    {
        stat.ChangeBaseValue(1);
        skillPoints--;
        if (skillPoints == 0)
        {
            onSpentLastSkillPoint?.Invoke(false);
        }
    }

    public void CalculateMods()
    {
        attack.ClearModifiers();
        defense.ClearModifiers();
        knockbackForce.ClearModifiers();
        knockbackDuration.ClearModifiers();

        foreach (EquipmentItem item in equipmentSO.currentEquipment)
        {
            defense.AddModifier(item.defenseModifier);
            attack.AddModifier(item.attackModifier);
            knockbackForce.AddModifier(item.knockbackForceModifier);
            knockbackDuration.AddModifier(item.knockbackDurationModifier);

            onStatsChanged.Raise();
        }
    }

    // listens for Equip from EquipmentManager
    public void AddModifiers(EquipmentItem newItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
            knockbackForce.AddModifier(newItem.knockbackForceModifier);
            knockbackDuration.AddModifier(newItem.knockbackDurationModifier);

            onStatsChanged.Raise();
        }
    }

    // listens for Unequip from EquipmentManager
    public void RemoveModifiers(EquipmentItem oldItem)
    {
        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
            knockbackForce.RemoveModifier(oldItem.knockbackForceModifier);
            knockbackDuration.RemoveModifier(oldItem.knockbackDurationModifier);

            onStatsChanged.Raise();
        }
    }
}