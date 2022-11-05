using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirectoryPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirectoryPath, string dataFileName)
    {
        this.dataDirectoryPath = dataDirectoryPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load(string profileID)
    {
        // Base case: if the profileID is null, return right away
        if (profileID == null)
        {
            return null;
        }

        // Use Path.Combine to account for different OS's having different path separators.
        string fullPath = Path.Combine(dataDirectoryPath, profileID, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // Load the serialized data from the file.
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize the data from Json back into the C# object.
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError(
                    "Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data, string profileID)
    {
        // Base case: if the profileID is null, return right away
        if (profileID == null)
        {
            return;
        }

        // Use Path.Combine to account for different OS's having different path separators.
        string fullPath = Path.Combine(dataDirectoryPath, profileID, dataFileName);
        try
        {
            // Create the directory the file will be written to if it doesn't already exist.
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialize the C# game data object into Json.
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write the serialized data to the file.
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(
                "Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        // Loop over all directory names in the data directory path
        IEnumerable<DirectoryInfo> directoryInfos = 
            new DirectoryInfo(dataDirectoryPath).EnumerateDirectories();

        foreach (DirectoryInfo directoryInfo in directoryInfos)
        {
            string profileID = directoryInfo.Name;

            // Defensive programming - check if the data file exists
            // If it doesn't, then this folder isn't a profile and should be shipped
            string fullPath = Path.Combine(dataDirectoryPath, profileID, dataFileName);
            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because " +
                    "it does not contain data:" + profileID);
                continue;
            }

            // Load the game data for this profile and put it in the dictionary
            GameData profileData = Load(profileID);
            // Defensive programming - ensure the profile data isn't null,
            // because if it is then something went wrong and we should let ourselves know
            if (profileData != null)
            {
                profileDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. ProfileID: "
                    + profileID);
            }
        }

        return profileDictionary;
    }

    public string GetMostRecentlyUpdatedProfileID()
    {
        string mostRecentProfileID = null;

        Dictionary<string, GameData> profilesGameData = LoadAllProfiles();
        foreach (KeyValuePair<string,GameData> pair in profilesGameData)
        {
            string profileID = pair.Key;
            GameData gameData = pair.Value;

            // Skip this entry if the gameData is null
            if (gameData == null)
            {
                continue;
            }

            // If this is the first data we've come across, it's the most recent so far
            if (mostRecentProfileID == null)
            {
                mostRecentProfileID = profileID;
            }
            // Otherwise, compare to see which date is the most recent
            else
            {
                DateTime mostRecentDateTime = 
                    DateTime.FromBinary(profilesGameData[mostRecentProfileID].lastUpdated);

                DateTime newDateTime = DateTime.FromBinary(gameData.lastUpdated);

                // The greatest DateTime value is the most recent
                if (newDateTime > mostRecentDateTime)
                {
                    mostRecentProfileID = profileID;
                }
            }
        }

        return mostRecentProfileID;
    }
}