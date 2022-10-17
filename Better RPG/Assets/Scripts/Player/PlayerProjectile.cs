using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProjectile : MonoBehaviour
{
    //BASE CLASS FOR PLAYER PROJECTILES

    [SerializeField] int damage = 1;

    [SerializeField] float knockbackForce = 1f;
    [SerializeField] float knockbackDuration = 2f;
    private Vector3 knockbackDirection;

    [SerializeField] float speed = 8f;

    [SerializeField] float lifetimeLength = 1f;
    float lifetimeTimer;

    Rigidbody2D rb;

    public GameEventAudioClip onPlayClip;
    public AudioClip hitClip;

    private void OnEnable()
    {
        lifetimeTimer = lifetimeLength;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lifetimeTimer -= Time.deltaTime;

        if (lifetimeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector2 direction, Vector3 orientation)
    {
        rb.velocity = direction.normalized * speed;
        transform.rotation = Quaternion.Euler(orientation);
        knockbackDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.GetComponent<EnemyHealthManager>() != null)
            {
                collision.GetComponent<EnemyHealthManager>().TakeDamage(damage);

                // knockback & temporary invulnerability
                Vector2 direction = collision.transform.position - transform.position;
                direction.Normalize();

                collision.gameObject.GetComponent<KnockbackEnemy>().GetKnockedBack
                    (knockbackForce * direction, knockbackDuration);

                onPlayClip.Raise(hitClip);
            }
        }

        gameObject.SetActive(false);
    }
}