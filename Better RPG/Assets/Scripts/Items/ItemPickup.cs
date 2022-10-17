using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : Interactable
{
    public Item item;

    public GameEventItem OnPickUp;

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

       // PlaySound();

        // InvManager listens for this, adds item to inv
        OnPickUp.Raise(item);

        // AudioManager listens, plays clip
        OnPlayClip.Raise(clip);

        Destroy(gameObject);
    }
}