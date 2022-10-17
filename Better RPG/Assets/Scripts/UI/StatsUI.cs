using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUIPanel;

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

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction openInventory;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        openInventory = playerControls.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenStats;
    }

    private void OnDisable()
    {
        openInventory.Disable();
    }

    void Start()
    {
        UpdateStats();
    }

    void OpenStats(InputAction.CallbackContext context)
    {
        statsUIPanel.SetActive(!statsUIPanel.activeSelf);
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