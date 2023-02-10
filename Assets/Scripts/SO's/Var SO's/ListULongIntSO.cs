using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListULongIntSO", menuName = "Vars/ListULongIntSO")]
public class ListULongIntSO : ScriptableObject
{
    public List<ULongInt> uLongInts = new List<ULongInt>();
}

[System.Serializable]
public class ULongInt
{
    // global target object ID
    public ulong ulongValue;

    // health. if zero, deactivate object
    public int intValue;
}