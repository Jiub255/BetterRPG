using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] int baseValue;
    // just to see in the inspector, var has no real use
    [SerializeField] int moddedValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);// what's this code trick?
        return finalValue;
    }

    public void ChangeBaseValue(int amount)
    {
        baseValue += amount;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
        moddedValue = GetValue();
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
        moddedValue = GetValue();
    }
}