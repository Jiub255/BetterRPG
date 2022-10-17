using UnityEngine;
 
[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    Enemy enemy;

    float attackTimer;
    bool canAttack;

    // sound effect signal
    public GameEventAudioClip onPlayClip;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        attackTimer = enemy.attackTimerLength;
    }

    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = enemy.attackTimerLength;
                canAttack = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack) // && not stunned
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(enemy.attack);

                // knockback & temporary invulnerability
                Vector3 direction = collision.transform.position - transform.position;
                direction.Normalize();

                collision.gameObject.GetComponent<KnockbackPlayer>().GetKnockedBack
                    (enemy.knockbackForce * direction, enemy.knockbackDuration);

                onPlayClip.Raise(enemy.hitPlayerClip);

                canAttack = false;
            }
        }
    }
}