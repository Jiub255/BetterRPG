using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    //public int Experience { get; private set; }
    public IntSO Experience;

    [SerializeField] private List<int> expLevels;
    //public int Level { get; private set; } = 1;
    public IntSO Level;
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

    public void GainExperience(int amount)
    {
        if (Level.value < maxLevel)
        {
            Experience.value += amount;

            if (Experience.value >= expLevels[Level.value - 1])
            {
                LevelUp();
            }
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
    }
}