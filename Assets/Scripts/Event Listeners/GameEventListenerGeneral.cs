using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerGeneral<T> : MonoBehaviour where T : Component
{
    public GameEventGeneral<T> Event;
    public UnityEvent<T> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(T t)
    {
        Response.Invoke(t);
    }
}