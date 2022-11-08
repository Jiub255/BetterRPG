using System;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public HealthSO healthSO;
    public Text healthText;
    
    public StatSO attackSO;
    public Text attackText;

    public StatSO defenseSO;
    public Text defenseText;

    public IntSO levelSO;
    public Text levelText;

    public IntSO experienceSO;
    public Text experienceText;

    public HealthSO magicSO;
    public Text magicText;

    private StatManager statManager;

    [SerializeField]
    private GameObject[] levelUpButtons;

    public static event Action<StatSO> onRaiseStat;

    void Start()
    {
        UpdateStats();
    }

    private void OnEnable()
    {
        StatManager.onSpentLastSkillPoint += ToggleLevelUpButtons;
    }

    private void OnDisable()
    {
        StatManager.onSpentLastSkillPoint -= ToggleLevelUpButtons;
    }

    public void GetPlayerReference(Transform transform)
    {
        statManager = transform.GetComponent<StatManager>();
    }

    public void RaiseStat(StatSO stat)
    {
        onRaiseStat?.Invoke(stat);
        statManager.CalculateStatModifiers();
    }

    public void ToggleLevelUpButtons(bool enable)
    {
        foreach (GameObject button in levelUpButtons)
        {
            button.SetActive(enable);
        }
    }

    public void UpdateStats()
    {
        healthText.text = "Health: " + healthSO.currentValue + " / " + healthSO.maxValue;
        attackText.text = "Attack: " + attackSO.GetValue();
        defenseText.text = "Defense: " + defenseSO.GetValue();
        levelText.text = "Level: " + levelSO.value;
        experienceText.text = "Experience: " + experienceSO.value;
        magicText.text = "Magic: " + magicSO.currentValue + " / " + magicSO.maxValue;
    }
}