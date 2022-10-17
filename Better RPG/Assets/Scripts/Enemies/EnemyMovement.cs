using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    Transform target;

    Rigidbody2D rb;

    float distance;

    Enemy enemy;

    bool playerInstantiated = false;

    public bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    public void GetPlayerReference(Transform playerTransform)
    {
        target = playerTransform;
        playerInstantiated = true;
    }

    private void Update()
    {
        if (playerInstantiated && canMove)
        {
            distance = Vector2.Distance(target.position, transform.position);
        }
    }

    // could do this inside OnTriggerStay? 
    private void FixedUpdate()
    {
        if (playerInstantiated && canMove) 
        {
            if (distance < enemy.chaseRadius)
            {
                ChaseTarget();
            }
            else
            {
                Wander();
            }
        }
    }

    private void ChaseTarget()
    {
        Vector2 movementVector = Vector2.MoveTowards(transform.position, target.position,
            enemy.moveSpeed * Time.deltaTime);
        rb.MovePosition(movementVector);
    }

    private void Wander()
    {
        // some random wandering stuff
    }
}