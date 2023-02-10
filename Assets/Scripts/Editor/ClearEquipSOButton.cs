using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EquipmentSO))]
public class ClearEquipSOButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EquipmentSO myScript = (EquipmentSO)target;
        if (GUILayout.Button("Clear Equipment SO"))
        {
            myScript.ClearEquipment();
        }
    }
}