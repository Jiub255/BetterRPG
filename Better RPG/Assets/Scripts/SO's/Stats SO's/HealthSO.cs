using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health SO", menuName = "Stats/Health SO")]
public class HealthSO : ScriptableObject
{
    public int maxValue;
    public int currentValue;
}