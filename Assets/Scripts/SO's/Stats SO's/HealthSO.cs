using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Health SO", menuName = "Stats/Health SO")]
public class HealthSO : ScriptableObject
{
    public int maxValue;
    public int currentValue;
}