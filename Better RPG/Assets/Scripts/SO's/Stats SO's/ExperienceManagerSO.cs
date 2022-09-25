using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Experience Manager SO", menuName = "Stats/Experience Manager")]
public class ExperienceManagerSO : ScriptableObject
{
    public int Experience { get; private set; }
    [SerializeField] private List<int> expLevels;
    public int Level { get; private set; } = 1;
    [SerializeField] private int maxLevel = 25;
    [SerializeField] private int expToFirstLevelUp = 3;
    [SerializeField] private float nextLvlMultiplier = 1.3f;

    void InitializeExp() 
    { 
        expLevels = new List<int>();
        int expToNextLvlUp = expToFirstLevelUp;
        for (int i = 0; i<maxLevel; i++)
        {
            expToNextLvlUp = Mathf.RoundToInt(expToNextLvlUp* nextLvlMultiplier);
            expLevels.Add(expToNextLvlUp);
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
}