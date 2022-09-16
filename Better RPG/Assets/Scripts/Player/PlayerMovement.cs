using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public float speed = 5f;
    public float atkSpdMultiplier = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", movement.sqrMagnitude);

        movement.Normalize();

        animator.SetFloat("Horiz", movement.x);
        animator.SetFloat("Vert", movement.y);

        if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat("LastHoriz", movement.x);
            animator.SetFloat("LastVert", movement.y);
        }
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("IsAttacking") == true || animator.GetBool("IsShooting") == true)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime * atkSpdMultiplier);
        }
        else
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}