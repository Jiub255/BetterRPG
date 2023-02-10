using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePrefabInstantiator : MonoBehaviour
{
    [Header("Don't put player prefab in here")]
    public List<GameObject> PrefabsToKeepInEveryScene = new List<GameObject>();

    [Header("Put player prefab in here")]
    public GameObject player;

    [Header(" ")] // just to make it look nicer in the inspector
    public GameEventTransform onPlayerInstantiated;

    // calls this method when it hears the OnSceneChanged Signal
    public void InstantiatePrefabs(Scene newScene, Vector3 startingPosition)
    {
        // Instantiate all the menus, camera, etc.
        foreach (GameObject thing in PrefabsToKeepInEveryScene)
        {
            Instantiate(thing);
        }

        // Instantiate player, get reference to transform for moving to starting position
        Transform playerTransform = Instantiate(player).transform;

        // Send signal for RoomTransition scripts to get reference to player,
        // now that it is instantiated in the scene
        // could have SceneMusic listen for this to send its signal to AudioManager
        onPlayerInstantiated.Raise(playerTransform);

        // Move player to starting position
        playerTransform.position = startingPosition;
    }
}