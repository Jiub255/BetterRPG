using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;

    public float speed = 5f;
    public float atkSpdMultiplier = 0.2f;

    PlayerMelee playerMelee;

    public bool canMove = true;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();

        playerMelee = gameObject.GetComponent<PlayerMelee>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("LastVert", -1);
    }

    void Update()
    {
        if (canMove)
        {
            movement = move.ReadValue<Vector2>();

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
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (playerMelee.canAttack)
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime * atkSpdMultiplier);
            }
        }
    }
}