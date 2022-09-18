using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SO List", menuName = "Inventory/SO List")]
public class SOListSO : ScriptableObject
{
    public List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();
}