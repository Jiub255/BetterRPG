using UnityEngine;

public class DamageMeleeWeapon : MonoBehaviour
{
    StatManager statManager;

    public GameEventAudioClip onPlayClip;
    public AudioClip hitClip;

    private void Awake()
    {
        if (gameObject.GetComponentInParent<StatManager>() != null)
        {
            statManager = gameObject.GetComponentInParent<StatManager>();
        }
        else
        {
            Debug.LogWarning("No StatManager found on player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.GetComponent<EnemyHealthManager>() != null)
            {
                collision.GetComponent<EnemyHealthManager>().TakeDamage(statManager.attack.GetValue());

                // knockback & temporary invulnerability
                Vector2 direction = collision.transform.position - transform.position;
                direction.Normalize();

                collision.gameObject.GetComponent<KnockbackEnemy>().GetKnockedBack
                    (statManager.knockbackForce.GetValue() * direction,
                     statManager.knockbackDuration.GetValue());

                onPlayClip.Raise(hitClip);
            }
        }
    }
}