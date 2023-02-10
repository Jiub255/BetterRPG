using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (Bool)",
    menuName = "Game Events/Game Event (Bool)")]
public class GameEventBool : ScriptableObject
{
    private List<GameEventListenerBool> listeners =
        new List<GameEventListenerBool>();

    public void Raise(bool Bool)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Bool);
        }
    }

    public void RegisterListener(GameEventListenerBool listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerBool listener)
    {
        listeners.Remove(listener);
    }
}