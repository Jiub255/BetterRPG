using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager2 : MonoBehaviour
{
    public static SaveManager2 saveManager;

    public float health;
    public float experience;

    void Awake()
    {
        if (saveManager == null)
        {
            DontDestroyOnLoad(gameObject);
            saveManager = this;
        }
        else if (saveManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        // want to just overwrite data if file already exists instead of creating new one
        // also want to create multiple save files (eg /playerInfo1.dat, etc)
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float experience;
}