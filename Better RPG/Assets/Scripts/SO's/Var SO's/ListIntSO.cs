using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListIntSO", menuName = "Vars/ListIntSO")]
public class ListIntSO : ScriptableObject
{
    public List<int> ints = new List<int>();
}