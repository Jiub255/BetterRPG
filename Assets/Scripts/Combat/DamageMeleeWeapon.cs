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
        if (!collision.isTrigger/* && collision.isActiveAndEnabled && collision.CompareTag("Alive")*/)
        {
            if (collision.GetComponentInParent<IDamageable<int>>() != null)
            {
                collision.GetComponentInParent<IDamageable<int>>().TakeDamage(statManager.attack.GetValue());

                onPlayClip.Raise(hitClip);

                if (collision.GetComponent<KnockbackEnemy>() != null)
                {
                    // knockback & temporary invulnerability
                    Vector2 direction = collision.transform.position - transform.position;
                    direction.Normalize();

                    collision.gameObject.GetComponent<KnockbackEnemy>().GetKnockedBack
                        (statManager.knockbackForce.GetValue() * direction,
                         statManager.knockbackDuration.GetValue());
                }
            }
        }
    }
}