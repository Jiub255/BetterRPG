using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    Animator animator;

    // keep longer than max length of all attack animations
    // just store statSO speed here instead of attacktimerlength, and calculate timer 
    // length based off of the speed statSO
    [SerializeField] 
    private float attackTimerLength = 0.4f;
    private float attackTimer;
    public bool canAttack { get; private set; } = true;

    // sound effect
    [SerializeField]
    private GameEventAudioClip onPlayClip;
    [SerializeField]
    private AudioClip swingClip;

    // new input system stuff
    private InputAction swing;

    private bool swingActive = true;

    private void Awake()
    {
        attackTimer = attackTimerLength;
    }

    private void OnEnable()
    {
        swing = InputManager.inputActions.Player.Swing;
        swing.Enable();
        swing.performed += Swing;
    }

    private void OnDisable()
    {
        swing.Disable();
        swing.performed -= Swing;
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // might not need this? animator taking care of it? by using trigger instead of bool for IsAttacking?
    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerLength;
                canAttack = true;
                EnableSwing();
            }
        }
    }

    private void Swing(InputAction.CallbackContext context)
    {
        animator.SetTrigger("AttackTrigger");

        onPlayClip.Raise(swingClip);

        canAttack = false;
        attackTimer = attackTimerLength;
        DisableSwing();
    }

    public void EnableSwing()
    {
        swing.performed += Swing;
        swingActive = true;
    }

    public void DisableSwing()
    {
        swing.performed -= Swing;
        swingActive = false;
    }

    // listens for dontAttack signal
    // called when near signs, maybe other things
    public void ToggleSwing()
    {
        if (swingActive)
            DisableSwing();
        else
            EnableSwing();
    }
}