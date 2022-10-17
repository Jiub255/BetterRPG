using UnityEngine;

public class PlayerMagicManager : MonoBehaviour
{
    public HealthSO magic;

    // statUI listens
    public GameEvent onMagicChanged;

    #region debug button stuff

    public static bool buttonPressed = false;
    [SerializeField] float timerLength = 0.03f;
    float timer;
    [SerializeField] float delay = 0.5f;

    public static int eventIndex;

    private void Start()
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
        // 1 for regenerate, 2 for use
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
                    RegenerateMagic(1);
                }
                else if (eventIndex == 2)
                {
                    LoseMagic(1);
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void LoseMagic(int amount)
    {
        if (amount <= magic.currentValue)
        {
            magic.currentValue -= amount;
            onMagicChanged.Raise();
        }
    }

    #endregion

    public void RegenerateMagic(int amount)
    {
        magic.currentValue += amount;
        if (magic.currentValue > magic.maxValue)
        {
            magic.currentValue = magic.maxValue;
            onMagicChanged.Raise();
        }

        onMagicChanged.Raise();
    }

    public bool UseMagic(int amount)
    {
        if (amount > magic.currentValue)
        {
            Debug.Log("Not enough magic");
            return false;
        }
        else
        {
            magic.currentValue -= amount;
            onMagicChanged.Raise();
            return true;
        }
    }
}