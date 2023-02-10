using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Game Event (SceneVector3)",
    menuName = "Game Events/Game Event (SceneVector3)")]
public class GameEventSceneVector3 : ScriptableObject
{
    private List<GameEventListenerSceneVector3> listeners =
        new List<GameEventListenerSceneVector3>();

    public void Raise(Scene Scene, Vector3 vector3)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Scene, vector3);
        }
    }

    public void RegisterListener(GameEventListenerSceneVector3 listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerSceneVector3 listener)
    {
        listeners.Remove(listener);
    }
}