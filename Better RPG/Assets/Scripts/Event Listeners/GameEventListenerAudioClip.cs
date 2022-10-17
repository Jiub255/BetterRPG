using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerAudioClip : MonoBehaviour
{
    public GameEventAudioClip Event;
    public UnityEvent<AudioClip> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(AudioClip AudioClip)
    {
        Response.Invoke(AudioClip);
    }
}