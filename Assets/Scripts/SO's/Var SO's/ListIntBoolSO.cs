using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListIntBoolSO", menuName = "Vars/ListIntBoolSO")]
public class ListIntBoolSO : ScriptableObject
{
    public List<IntBool> intBools = new List<IntBool>();
}

[System.Serializable]
public class IntBool
{
    public int intValue;
    public bool boolValue;
}