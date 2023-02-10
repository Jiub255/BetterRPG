using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerTransform : MonoBehaviour
{
    public GameEventTransform Event;
    public UnityEvent<Transform> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Transform Transform)
    {
        Response.Invoke(Transform);
    }
}