using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats SO", menuName = "Stats/Player Stats")]
public class PlayerStatsSO : CharacterStatsSO
{
    public delegate void OnStatsChanged();
    public OnStatsChanged onStatsChanged;

    public EquipmentSO equipmentSO;

    public int Experience { get; private set; }
    [SerializeField] private List<int> expLevels;
    public int Level { get; private set; } = 1;
    [SerializeField] private int maxLevel = 25;
    [SerializeField] private int expToFirstLevelUp = 3;
    [SerializeField] private float nextLvlMultiplier = 1.3f;

    void Start() // wont be called. It's an SO, not monobehaviour
    {
        equipmentSO.onEquipmentChanged += OnEquipmentChanged;
        //MasterSingleton.Instance.EquipmentManager.onEquipmentChanged += OnEquipmentChanged;
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
/*        if (Input.GetKeyDown(KeyCode.T))
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
        }*/
    }

    void OnEquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem)
    {
        if (newItem != null)
        {
            defense.AddModifier(newItem.defenseModifier);
            attack.AddModifier(newItem.attackModifier);
            onStatsChanged?.Invoke();
        }

        if (oldItem != null)
        {
            defense.RemoveModifier(oldItem.defenseModifier);
            attack.RemoveModifier(oldItem.attackModifier);
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