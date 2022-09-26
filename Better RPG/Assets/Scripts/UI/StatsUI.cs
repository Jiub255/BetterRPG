using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUI;

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

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            statsUI.SetActive(!statsUI.activeSelf);
        }
    }

    public void UpdateStats()
    {
        Debug.Log("Updating Stats UI");

        healthText.text = "Health: " + healthSO.currentHealth + " / " + healthSO.maxHealth;
        attackText.text = "Attack: " + attackSO.GetValue();
        defenseText.text = "Defense: " + defenseSO.GetValue();
        levelText.text = "Level: " + levelSO.value;
        experienceText.text = "Experience: " + experienceSO.value;
    }
}