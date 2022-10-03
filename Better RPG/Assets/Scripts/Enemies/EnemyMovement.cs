using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
   // [SerializeField] float moveSpeed = 1f;

    Transform target;

    Rigidbody2D rb;

    float distance;

   // [SerializeField] float chaseRadius = 5f;

    Enemy enemy;

    private void Start()
    {
        // target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    public void GetPlayerReference(Transform playerTransform)
    {
        target = playerTransform;
    }

    private void Update()
    {
        distance = Vector2.Distance(target.position, transform.position);
    }

    private void FixedUpdate()
    {
        if (distance < enemy.chaseRadius)
        {
            Vector2 movementVector = Vector2.MoveTowards(transform.position, target.position,
                enemy.moveSpeed * Time.deltaTime);
            rb.MovePosition(movementVector);
        }
    }
}