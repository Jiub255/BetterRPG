using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public delegate void OnStatsChanged();
    public OnStatsChanged onStatsChanged;

    public int Experience { get; private set; }
    [SerializeField] private List<int> expLevels;
    public int Level { get; private set; } = 1;
    [SerializeField] private int maxLevel = 25;
    [SerializeField] private int expToFirstLevelUp = 3;
    [SerializeField] private float nextLvlMultiplier = 1.3f;

    void Start()
    {  
        MasterSingleton.Instance.EquipmentManager.onEquipmentChanged += OnEquipmentChanged;
        expLevels = new List<int>();
        int expToNextLvlUp = expToFirstLevelUp;
        for (int i = 0; i < maxLevel; i++)
        {
            expToNextLvlUp = Mathf.RoundToInt(expToNextLvlUp * nextLvlMultiplier);
            expLevels.Add(expToNextLvlUp);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeHealth(1);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeStat(maxHealth, 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeStat(attack, 1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeStat(defense, 1);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.armorModifier);
            attack.AddModifier(newItem.damageModifier);
            onStatsChanged?.Invoke();
        }

        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.armorModifier);
            attack.RemoveModifier(oldItem.damageModifier);
            onStatsChanged?.Invoke();
        }
    }

    public void GainExperience(int amount)
    {
        if (Level < maxLevel)
        {
            Experience += amount;

            if (Experience >= expLevels[Level - 1])
            {
                LevelUp();
            }
        }
    }

    private void LevelUp()
    {
        if (Level < maxLevel)
        {
            Level++;
        }

        else //if (Level >= maxLevel)
        {
            Level = maxLevel;
            // say exp: max? or something
        }
        // maybe give some stat points?
    }

    public override void Die()
    {
        base.Die();
        //kill the player
        //reset scene. do this in PlayerManager(singleton)?
        MasterSingleton.Instance.PlayerManager.KillPlayer();
    }
}