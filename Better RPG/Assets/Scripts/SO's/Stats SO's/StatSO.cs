using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Stat SO", menuName = "Stats/Stat")]
public class StatSO : ScriptableObject
{
    [SerializeField] int baseValue;
    [SerializeField] List<int> modifiers = new List<int>();

    // just to see in the inspector, var has no real use
    [SerializeField] string statName;
    [SerializeField] int moddedValue;

    // stat based experience. not sure about this yet
    /*public int experience;
    public int level = 1;*/

/*    public void GainExperience(int amount)
    {
        experience += amount;
    }*/

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);// what's this code trick?
        return finalValue;
    }

    public void ChangeBaseValue(int amount)
    {
        baseValue += amount;
        moddedValue = GetValue();
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }

        moddedValue = GetValue();
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }

        moddedValue = GetValue();
    }

    public void ClearModifiers()
    {
        modifiers.Clear();

        moddedValue = GetValue();
    }
}