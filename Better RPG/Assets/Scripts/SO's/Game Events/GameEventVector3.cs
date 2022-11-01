using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (Vector3)",
    menuName = "Game Events/Game Event (Vector3)")]
public class GameEventVector3 : ScriptableObject
{
    private List<GameEventListenerVector3> listeners =
        new List<GameEventListenerVector3>();

    public void Raise(Vector3 Vector3)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Vector3);
        }
    }

    public void RegisterListener(GameEventListenerVector3 listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerVector3 listener)
    {
        listeners.Remove(listener);
    }
}