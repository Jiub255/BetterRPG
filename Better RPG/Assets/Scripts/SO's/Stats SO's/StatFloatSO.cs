using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Stat Float SO", menuName = "Stats/Stat Float")]
public class StatFloatSO : ScriptableObject
{
    [SerializeField] float baseValue;
    [SerializeField] List<float> modifiers = new List<float>();

    // just to see in the inspector, var has no real use
    [SerializeField] string statName;
    [SerializeField] float moddedValue;

    // stat based experience. not sure about this yet
    /*public int experience;
    public int level = 1;*/

    /*    public void GainExperience(int amount)
        {
            experience += amount;
        }*/

    public float GetValue()
    {
        float finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);// what's this code trick?
        return finalValue;
    }

    public void ChangeBaseValue(float amount)
    {
        baseValue += amount;
    }

    public void AddModifier(float modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }

        moddedValue = GetValue();
    }

    public void RemoveModifier(float modifier)
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
    }
}