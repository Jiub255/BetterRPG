using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ImmediatelyUseItem : Interactable
{
    public ImmediateUseItem item;

    public GameEventAudioClip OnPlayClip;
    public AudioClip clip;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.icon;
    }

    public override void Interact(Collider2D collision)
    {
        base.Interact(collision);
        
        item.itemEffect.Invoke();

        // AudioManager listens, plays clip
        OnPlayClip.Raise(clip);

        Destroy(gameObject);
    }
}