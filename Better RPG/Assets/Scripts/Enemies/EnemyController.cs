using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float chaseRadius = 10f;
    public float stoppingDistance = 1f;
    public float moveSpeed = 1f;

    Rigidbody2D rb;
    Transform target;
    CharacterCombat characterCombat;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        characterCombat = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= chaseRadius)
        {
            Vector2 movementVector = Vector2.MoveTowards(transform.position, target.position,
                 moveSpeed * Time.deltaTime);
            rb.MovePosition(movementVector);

            if (distance <= stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    characterCombat.Attack(targetStats);
                }
            }
        }
    }
}