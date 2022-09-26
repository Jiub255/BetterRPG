using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (Transform)",
    menuName = "Game Events/Game Event (Transform)")]
public class GameEventTransform : ScriptableObject
{
    private List<GameEventListenerTransform> listeners =
        new List<GameEventListenerTransform>();

    public void Raise(Transform Transform)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Transform);
        }
    }

    public void RegisterListener(GameEventListenerTransform listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerTransform listener)
    {
        listeners.Remove(listener);
    }
}