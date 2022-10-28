using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour ,
    IDamageable<int>, IHealable<int>, IDataPersistence
{
    public HealthSO health;

    public GameEventSceneVector3 onDied;

    StatManager statManager;

    public StringSO sceneNameSO;

    public bool invulnerable = false;

    // statUI listens for this
    public GameEvent onHealthChanged;

    #region debug button stuff

    public static bool buttonPressed = false;
    [SerializeField] float timerLength = 0.03f;
    float timer;
    [SerializeField] float delay = 0.5f;

    public static int eventIndex;

    private void Awake()
    {
        timer = delay;
    }

    public void ChangeButtonPressed(bool isPressed)
    {
        buttonPressed = isPressed;

        if (isPressed == false)
        {
            timer = delay;
        }
    }

    public void ChangeEvent(int currentEventIndex)
    {
        eventIndex = currentEventIndex;
        // 1 for Heal, 2 for TakeDamageNoArmor
    }

    private void Update()
    {
        // hacky fix to timer not getting reset to delay when you let go of mouse button
        if (!buttonPressed)
        {
            timer = delay;
        }

        if (buttonPressed)
        {
            if (timer <= 0f)
            {
                timer = timerLength;

                if (eventIndex == 1)
                {
                    Heal(1);
                }
                else if (eventIndex == 2)
                {
                    TakeDamageNoArmor(1);
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

#endregion

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

    // Have a separate scene manager for this? singleton?
    // Or use SceneTransition script?
    IEnumerator ReloadScene()
    {
        // get player position
        Vector3 playerPosition = transform.position;

        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // set into SO?
        sceneNameSO.text = SceneManager.GetActiveScene().name;

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

    public void LoadData(GameData data)
    {
        health.currentValue = data.currentHealth;
    }

    public void SaveData(ref GameData data)
    {
        data.currentHealth = health.currentValue;
    }
}