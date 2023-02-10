using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerVector3 : MonoBehaviour
{
    public GameEventVector3 Event;
    public UnityEvent<Vector3> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Vector3 Vector3)
    {
        Response.Invoke(Vector3);
    }
}