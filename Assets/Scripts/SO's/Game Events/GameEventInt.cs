using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (Int)",
    menuName = "Game Events/Game Event (Int)")]
public class GameEventInt : ScriptableObject
{
    private List<GameEventListenerInt> listeners =
        new List<GameEventListenerInt>();

    public void Raise(int Int)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Int);
        }
    }

    public void RegisterListener(GameEventListenerInt listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerInt listener)
    {
        listeners.Remove(listener);
    }
}