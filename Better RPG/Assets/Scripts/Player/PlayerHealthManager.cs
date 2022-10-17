using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour , IDamageable<int>
{
    public HealthSO health;

    public GameEventSceneVector3 onDied;

    StatManager statManager;

    public StringSO sceneNameSO;

    public bool invulnerable = false;

    // statUI listens for this
    public GameEvent onHealthChanged;

    private void Start()
    {
        statManager = gameObject.GetComponent<StatManager>();

        // just for testing. dont want to heal player every scene change
        MaxHeal();
    }

    public void TakeDamage(int amount)
    {
        if (!invulnerable)
        {
            health.currentValue -= amountAfterDefense(amount);

            if (health.currentValue <= 0)
            {
                health.currentValue = 0;
                onHealthChanged.Raise();
                Die();
            }

            onHealthChanged.Raise();
        }
    }

    public void TakeDamageNoArmor(int amount)
    {
        if (!invulnerable)
        {
            health.currentValue -= amount;

            if (health.currentValue <= 0)
            {
                health.currentValue = 0;
                onHealthChanged.Raise();
                Die();
            }

            onHealthChanged.Raise();
        }
    }

    int amountAfterDefense(int amount)
    {
        amount -= statManager.defense.GetValue();
        if (amount <= 0)
            return 0;
        return amount;
    }

    public void Heal(int amount)
    {
        health.currentValue += amount;

        if (health.currentValue > health.maxValue)
            health.currentValue = health.maxValue;

        onHealthChanged.Raise();
    }

    public void MaxHeal()
    {
        health.currentValue = health.maxValue;
        onHealthChanged.Raise();
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