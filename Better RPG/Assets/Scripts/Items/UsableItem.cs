using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Usable Item", menuName = "Inventory/Usable Item")]
public class UsableItem : ItemSO
{
    public bool isReusable = false;

    public UnityEvent itemEffect;

    public override void Use()
    {
        base.Use();

        itemEffect.Invoke();

        if (!isReusable)
        {
            RemoveFromInventory();
        }
    }
}