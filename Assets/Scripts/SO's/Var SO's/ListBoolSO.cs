using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListBoolSO", menuName = "Vars/ListBoolSO")]
public class ListBoolSO : ScriptableObject
{
    public List<bool> boolList = new List<bool>();
}