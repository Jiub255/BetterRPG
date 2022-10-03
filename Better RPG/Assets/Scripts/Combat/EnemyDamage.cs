using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    Enemy enemy;

    float attackTimer;
    [SerializeField] float attackTimerLength = 0.5f;
    bool canAttack;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
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

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(enemy.attack);
        }
    }*/

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(enemy.attack);
                canAttack = false;
            }
        }

    }
}