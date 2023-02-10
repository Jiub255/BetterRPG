using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;

    public float speed = 5f;
    public float atkSpdMultiplier = 0.2f;

    PlayerMelee playerMelee;

    public bool canMove = true;

    // Probably unnecessary
    private Vector3 savedPlayerPosition;
    private string currentSceneName;

    // new input system stuff
    private InputAction move;

    private void Awake()
    {
        playerMelee = gameObject.GetComponent<PlayerMelee>();
    }

    private void OnEnable()
    {
        StartCoroutine(OnEnableCo());
    }

    // I hate that this works
    IEnumerator OnEnableCo()
    {
        yield return new WaitForEndOfFrame();

        move = InputManager.inputActions.Player.Move;
        move.Enable();

        Sign.signalEventString += ToggleControls;
    }

    private void OnDisable()
    {
        move.Disable();

        Sign.signalEventString -= ToggleControls;
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
            if (playerMelee.swingActive)
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime * atkSpdMultiplier);
            }
        }
    }

    public void LoadData(GameData data)
    {
        savedPlayerPosition = new Vector3(data.playerXPosition, data.playerYPosition, 0f);

        transform.transform.position = savedPlayerPosition;

        canMove = data.canMove;

        // Probably unnecessary
        currentSceneName = data.currentSceneName;
    }

    public void SaveData(GameData data)
    {
        data.playerXPosition = transform.position.x;
        data.playerYPosition = transform.position.y;
        data.canMove = canMove;
        data.currentSceneName = SceneManager.GetActiveScene().name;
    }
}