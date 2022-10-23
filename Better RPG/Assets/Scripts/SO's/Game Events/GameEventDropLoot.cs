using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (DropLoot)",
    menuName = "Game Events/Game Event (DropLoot)")]
public class GameEventDropLoot : ScriptableObject
{
    private List<GameEventListenerDropLoot> listeners =
        new List<GameEventListenerDropLoot>();

    public void Raise(DropLoot dropLoot)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(dropLoot);
        }
    }

    public void RegisterListener(GameEventListenerDropLoot listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerDropLoot listener)
    {
        listeners.Remove(listener);
    }
}