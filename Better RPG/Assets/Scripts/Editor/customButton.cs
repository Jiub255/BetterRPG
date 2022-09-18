using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InventoryUI))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InventoryUI myScript = (InventoryUI)target;
        if (GUILayout.Button("Clear Inventory and Equipment So's"))
        {
            myScript.ClearInvAndEquip();
        }
    }
}