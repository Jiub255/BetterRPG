using UnityEngine;
 
//[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    //private Enemy enemy;

    [SerializeField]
    private float attackTimerLength = 0.3f;
    private float attackTimer;
    private bool canAttack;

    [SerializeField]
    public float knockbackForce = 10f;
    [SerializeField]
    public float knockbackDuration = 1f;
    [SerializeField]
    public int attack = 1;

    // sound effect signal
    [SerializeField] 
    private GameEventAudioClip onPlayClip;
    public AudioClip hitPlayerClip;

    private void Start()
    {
       // enemy = GetComponent<Enemy>();
        attackTimer = attackTimerLength;
    }

    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerLength;
                canAttack = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack) // && not stunned
        {
            if (collision.gameObject.GetComponent<PlayerHealthManager>())
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(attack);

                // knockback & temporary invulnerability
                Vector3 direction = collision.transform.position - transform.position;
                direction.Normalize();

                collision.gameObject.GetComponent<KnockbackPlayer>().GetKnockedBack
                    (knockbackForce * direction, knockbackDuration);

                onPlayClip.Raise(hitPlayerClip);

                canAttack = false;
            }
        }
    }
}