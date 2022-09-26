using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Game Event (Scene)",
    menuName = "Game Events/Game Event (Scene)")]
public class GameEventScene : ScriptableObject
{
    private List<GameEventListenerScene> listeners =
        new List<GameEventListenerScene>();

    public void Raise(Scene Scene)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(Scene);
        }
    }

    public void RegisterListener(GameEventListenerScene listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerScene listener)
    {
        listeners.Remove(listener);
    }
}