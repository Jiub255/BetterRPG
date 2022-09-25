using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event (EquipmentItem)",
    menuName = "Game Events/Game Event (EquipmentItem)")]
public class GameEventEquipmentItem : ScriptableObject
{
    private List<GameEventListenerEquipmentItem> listeners = 
        new List<GameEventListenerEquipmentItem>();

    public void Raise(EquipmentItem equipmentItem)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(equipmentItem);
        }
    }

    public void RegisterListener(GameEventListenerEquipmentItem listener)
    {
        listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListenerEquipmentItem listener)
    {
        listeners.Remove(listener);
    }
}