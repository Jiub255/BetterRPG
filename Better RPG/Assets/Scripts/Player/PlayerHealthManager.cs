using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour , IDamageable<int>
{
    public HealthSO health;

    public GameEventSceneVector3 onDied;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction hurtSelf;

    public StringSO sceneNameSO;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        hurtSelf = playerControls.Player.Shoot;
        hurtSelf.Enable();
        hurtSelf.performed += HurtSelf;
    }

    private void OnDisable()
    {
        hurtSelf.Disable();
    }

    // just for testing. dont want to heal player/enemies every scene change
    private void Start()
    {
        MaxHeal();
    }

    public void TakeDamage(int amount)
    {
        health.currentHealth -= amount;

        if (health.currentHealth <= 0)
        {
            health.currentHealth = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        health.currentHealth += amount;

        if (health.currentHealth > health.maxHealth)
            health.currentHealth = health.maxHealth;
    }

    public void MaxHeal()
    {
        health.currentHealth = health.maxHealth;
    }

    void HurtSelf(InputAction.CallbackContext context)
    {
        TakeDamage(1);
    }

    public void Die()
    {
        Debug.Log(transform.name + " died");

        MaxHeal();

        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        // get player position
        Vector3 playerPosition = transform.position;

        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // set into SO?
        sceneNameSO.String = SceneManager.GetActiveScene().name;

        Debug.Log("Current scene: " + currentScene.name);

        // Load the loading scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Send signal to LoadingScene
        onDied.Raise(currentScene, playerPosition);

        // Set loading scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LoadingScene"));

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}