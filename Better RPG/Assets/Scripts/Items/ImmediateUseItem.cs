using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Immediate Use Item", menuName = "Inventory/Immediate Use Item")]
public class ImmediateUseItem : ItemSO
{
    public UnityEvent itemEffect;
}