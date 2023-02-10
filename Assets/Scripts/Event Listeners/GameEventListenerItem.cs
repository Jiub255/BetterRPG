using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerItem : MonoBehaviour
{
    public GameEventItem Event;
    public UnityEvent<ItemSO> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(ItemSO Item)
    {
        Response.Invoke(Item);
    }
}