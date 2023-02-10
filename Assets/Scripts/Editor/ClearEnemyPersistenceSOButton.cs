using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPersistenceSO))]
public class ClearEnemyPersistenceSOButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EnemyPersistenceSO myScript = (EnemyPersistenceSO)target;
        if (GUILayout.Button("Clear Enemy Persistence SO"))
        {
            myScript.ClearPersistenceData();
        }
    }
}