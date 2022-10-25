using System.Collections;
using UnityEngine;

// on enemies
public class KnockbackEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    EnemyHealthManager enemyHealthManager;
    EnemyMovementTrigger enemyMovementTrigger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealthManager = GetComponent<EnemyHealthManager>();
        enemyMovementTrigger = GetComponent<EnemyMovementTrigger>();
    }

    public void GetKnockedBack(Vector3 knockbackVector, float stunDuration)
    {
        Debug.Log("Knockback Vector: " + knockbackVector + ", Stun Duration: " + stunDuration);

        StartCoroutine(StunDurationCoroutine(knockbackVector, stunDuration));
    }

    // how to do this without needing separate script for player and enemies?
    // might not be worth the effort, two scripts isn't bad
    private IEnumerator StunDurationCoroutine(Vector3 knockbackVector, float stunDuration)
    {
        //tell healthManager that you're invulnerable
        enemyHealthManager.invulnerable = true;

        //tell movement script that you can't move
        enemyMovementTrigger.canMove = false;

        // not sure if i need the next line here. could it be in GetKnockedBack?
        rb.AddForce(knockbackVector, ForceMode2D.Impulse);

        yield return new WaitForSeconds(stunDuration);

        rb.velocity = Vector2.zero;

        //tell healthManager that you're not invulnerable anymore
        enemyHealthManager.invulnerable = false;

        //tell movement script that you can move again
        enemyMovementTrigger.canMove = true;
    }
}