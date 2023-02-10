using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventorySO))]
public class ClearInvSOButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InventorySO myScript = (InventorySO)target;
        if (GUILayout.Button("Clear Inventory SO"))
        {
            myScript.ClearInventory();
        }
    }
}