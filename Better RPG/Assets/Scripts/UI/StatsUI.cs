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

    void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        healthText.text = "Health: " + healthSO.currentValue + " / " + healthSO.maxValue;
        attackText.text = "Attack: " + attackSO.GetValue();
        defenseText.text = "Defense: " + defenseSO.GetValue();
        levelText.text = "Level: " + levelSO.value;
        experienceText.text = "Experience: " + experienceSO.value;
    }
}