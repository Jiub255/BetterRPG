using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Getting from playerHealthSO.
    public int currentHealth; 

    public GameData()
    {
        this.currentHealth = 1;
    }
}