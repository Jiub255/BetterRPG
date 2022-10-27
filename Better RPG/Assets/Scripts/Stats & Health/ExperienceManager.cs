using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public IntSO Experience;
    public IntSO Level;
    // do I even want there to be a max level?
    [SerializeField] 
    private int maxLevel = 25;

    [SerializeField] 
    private List<int> expLevels;
    //public int Level { get; private set; } = 1;
    [SerializeField] 
    private int expToFirstLevelUp = 3;
    [SerializeField] 
    private float nextLvlMultiplier = 1.3f;

    [SerializeField]
    private GameEvent onStatsChanged;

    [SerializeField]
    private GameEvent onLevelUp;

    private StatManager statManager;

    //stat based exp
/*    public StatSO attack;
    public StatSO defense;*/
    //public List<StatSO> stats;

    private void Start()
    {
        InitializeExp();
        statManager = GetComponent<StatManager>();
    }

    void InitializeExp()
    {
        expLevels = new List<int>();
        int expToNextLvlUp = expToFirstLevelUp;
        for (int i = 0; i < maxLevel; i++)
        {
            expToNextLvlUp = Mathf.RoundToInt(expToNextLvlUp * nextLvlMultiplier);
            expLevels.Add(expToNextLvlUp);
        }

        for (int i = 0;i < expLevels.Count; i++)
        {
            bool notMaxLevel = false;

            if (Experience.value < expLevels[i])
            {
                Level.value = i + 1;
                notMaxLevel = true;
                break;
            }
            if (!notMaxLevel)
            {
                Level.value = maxLevel;
            }
        }

        onStatsChanged.Raise();
    }

    public void GainExperience(int amount)
    {
        if (Level.value < maxLevel)
        {
            Experience.value += amount;

            if (Experience.value >= expLevels[Level.value - 1])
            {
                LevelUp();
            }

            onStatsChanged.Raise();
        }
    }

    private void LevelUp()
    {
        if (Level.value < maxLevel)
        {
            Level.value++;
        }

        else //if (Level >= maxLevel)
        {
            Level.value = maxLevel;
            // say exp: max? or something
        }
        // maybe give some stat points?
        statManager.skillPoints++;
        onLevelUp.Raise();
    }
}