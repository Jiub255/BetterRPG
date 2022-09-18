using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerItem : MonoBehaviour
{
    public GameEventItem Event;
    public UnityEvent<Item> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Item Item)
    {
        Response.Invoke(Item);
    }
}