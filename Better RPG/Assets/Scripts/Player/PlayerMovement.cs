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
    private InputAction move;

    private void Awake()
    {
        playerMelee = gameObject.GetComponent<PlayerMelee>();
    }

    private void OnEnable()
    {
        move = InputManager.inputActions.Player.Move;
        move.Enable();

        Sign.signalEventString += ToggleControls;

       // InputManager.actionMapChange += ChangeActionMap;
    }

    private void OnDisable()
    {
        move.Disable();

        Sign.signalEventString -= ToggleControls;

       // InputManager.actionMapChange -= ChangeActionMap;
    }

    // Do I need these in all "controller" scripts?
    // ie ones that take input from player
    void ChangeActionMap(InputActionMap actionMap)
    {
        actionMap.Enable();

        Debug.Log("Player Movement using " + actionMap.name);
    }

    // string argument here is just for getting the signal from the sign script
    // string doesn't have any real use
    public void ToggleControls(string asdf)
    {
        if (!move.enabled)
            move.Enable();
        else    
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