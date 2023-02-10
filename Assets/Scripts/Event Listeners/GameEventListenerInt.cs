using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerInt : MonoBehaviour
{
    public GameEventInt Event;
    public UnityEvent<int> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(int Int)
    {
        Response.Invoke(Int);
    }
}