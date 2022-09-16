using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;
    public static event UnityAction<float, Vector3> hit;

    CharacterStats attackerStats;

    Animator animator;

    private void Start()
    {
        attackerStats = GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            animator.SetBool("IsAttacking", true);

            // does this even get used?
            OnAttack?.Invoke();

            // not sure about this
            Vector3 knockbackDirection = (targetStats.gameObject.transform.position
                - attackerStats.gameObject.transform.position).normalized;
            hit?.Invoke(attackerStats.attack.GetValue(), knockbackDirection);

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(attackerStats.attack.GetValue());
    }
}