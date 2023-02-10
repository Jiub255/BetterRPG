using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerDropLoot : MonoBehaviour
{
    public GameEventDropLoot Event;
    public UnityEvent<DropLoot> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(DropLoot dropLoot)
    {
        Response.Invoke(dropLoot);
    }
}