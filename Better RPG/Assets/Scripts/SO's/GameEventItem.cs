using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (Item)",
    menuName = "Game Events/Game Event (Item)")]
public class GameEventItem : ScriptableObject
{
    private List<GameEventListenerItem> listeners =
        new List<GameEventListenerItem>();

    public void Raise(Item Item)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Item);
        }
    }

    public void RegisterListener(GameEventListenerItem listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerItem listener)
    {
        listeners.Remove(listener);
    }
}