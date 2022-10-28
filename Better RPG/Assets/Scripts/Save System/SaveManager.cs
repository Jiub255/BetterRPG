using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //[SerializeField] SaveData saveData;

    // Save/Load the data from SaveData class

    // How to know it's full of most recent data?
    // Keep it constantly updated? Or just fill it right before save?
    // Then should I just keep the data in SaveManager? Leaning towards no.

    SaveData saveData = new SaveData();

    public void SaveToFile(SaveData data)
    {
        saveData.GetValues(data);

        // Serialize data

    }
}