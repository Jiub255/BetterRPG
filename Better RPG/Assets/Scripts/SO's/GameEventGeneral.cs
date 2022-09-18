using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (General)",
    menuName = "Game Events/Game Event (General)")]
public class GameEventGeneral<T> : ScriptableObject where T : Component
{
    private List<GameEventListenerGeneral<T>> listeners = new List<GameEventListenerGeneral<T>>();

    public void Raise(T t)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(t);
        }
    }

    public void RegisterListener(GameEventListenerGeneral<T> listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerGeneral<T> listener)
    {
        listeners.Remove(listener);
    }
}