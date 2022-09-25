using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerEquipmentItem : MonoBehaviour
{
    public GameEventEquipmentItem Event;
    public UnityEvent<EquipmentItem> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(EquipmentItem equipmentItem)
    {
        Response.Invoke(equipmentItem);
    }
}