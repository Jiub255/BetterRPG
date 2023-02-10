using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManagerStatBased : MonoBehaviour
{
/*    //stat based exp
    public StatSO attack;
    public StatSO defense;
    //public List<StatSO> stats;

    [SerializeField] private List<int> expLevels;
    // do I even want there to be a max level?
    [SerializeField] private int maxLevel = 25;
    [SerializeField] private int expToFirstLevelUp = 3;
    [SerializeField] private float nextLvlMultiplier = 1.3f;

    private void Start()
    {
        InitializeExp();
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
    }

    public void GainExperience(StatSO stat, int amount)
    {
        if (stat.level < maxLevel)
        {
            stat.experience += amount;

            if (stat.experience >= expLevels[stat.level - 1])
            {
                LevelUp(stat);
            }
        }
    }

    private void LevelUp(StatSO stat)
    {
        if (stat.level < maxLevel)
        {
            stat.level++;
            stat.ChangeBaseValue(1);
        }

        else //if (Level >= maxLevel)
        {
            stat.level = maxLevel;
            // say exp: max? or something
        }
    }*/
}