using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListULongSO", menuName = "Vars/ListULongSO")]
public class ListULongSO : ScriptableObject
{
    public List<ulong> uLongs = new List<ulong>();
}