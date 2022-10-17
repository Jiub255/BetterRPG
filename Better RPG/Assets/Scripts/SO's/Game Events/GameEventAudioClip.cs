using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (AudioClip)",
    menuName = "Game Events/Game Event (AudioClip)")]
public class GameEventAudioClip : ScriptableObject
{
    private List<GameEventListenerAudioClip> listeners =
        new List<GameEventListenerAudioClip>();

    public void Raise(AudioClip AudioClip)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(AudioClip);
        }
    }

    public void RegisterListener(GameEventListenerAudioClip listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerAudioClip listener)
    {
        listeners.Remove(listener);
    }
}