using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemImmediateUse : Interactable
{
    public UnityEvent itemUseEvent;

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);

        UseItem();
    }

    private void UseItem()
    {
        itemUseEvent.Invoke();
    }
}