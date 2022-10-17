using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Immediate Use Item", menuName = "Inventory/Immediate Use Item")]
public class ImmediateUseItem : Item
{
    public UnityEvent itemEffect;
}