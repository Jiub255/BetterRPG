using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    Animator animator;

    //keep longer than max length of all attack animations
    public float attackTimerLength = 0.4f;
    float attackTimer;
    public bool canAttack { get; private set; } = true;

    // sound effect
    public GameEventAudioClip onPlayClip;
    public AudioClip swingClip;

    // new input system stuff
    InputAction swing;

    bool swingActive = true;

    private void Awake()
    {
        attackTimer = attackTimerLength;
    }

    private void OnEnable()
    {
        swing = InputManager.inputActions.Player.Swing;
        swing.Enable();
        swing.performed += Swing;

       // InputManager.actionMapChange += ChangeActionMap;
    }

    private void OnDisable()
    {
        swing.Disable();
        swing.performed -= Swing;
   
       // InputManager.actionMapChange -= ChangeActionMap;
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

    void Swing(InputAction.CallbackContext context)
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

    void ChangeActionMap(InputActionMap actionMap)
    {
        actionMap.Enable();
 
        Debug.Log("Player Melee using " + actionMap.name);
    }
}