using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (T)",
    menuName = "Game Events/Game Event (T)")] 
public class GameEventGeneric<T> : ScriptableObject
{
    private List<GameEventListenerGeneric<T>> listeners = new List<GameEventListenerGeneric<T>>();

    public void Raise(T t)
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(t);
        }
    }

    public void RegisterListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerGeneric<T> listener)
    {
        listeners.Remove(listener);
    }
}