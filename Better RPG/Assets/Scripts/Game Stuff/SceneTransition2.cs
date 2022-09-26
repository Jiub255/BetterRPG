using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition2 : MonoBehaviour
{
    public string sceneToLoad;

    // is this better? avoids using strings
    //public SceneReference scene2Load;

    public Vector2 startingPosition;

    [Header("Don't put player prefab in here")]
    public List<GameObject> thingsToKeepInNextScene = new List<GameObject>();

    [Header("Put player prefab in here")]
    public GameObject player;

    public GameEventTransform onPlayerInstantiated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));

        // Instantiate all the menus, camera, etc.
        foreach (GameObject thing in thingsToKeepInNextScene)
        {
            Instantiate(thing);
        }
        
        // Instantiate player, get reference to transform for moving to starting position
        Transform playerTransform = Instantiate(player).transform;

        // Send signal for RoomTransition scripts to get reference to player,
        // now that its instantiated in the scene
        onPlayerInstantiated.Raise(playerTransform);

        // Move player to starting position
        playerTransform.position = startingPosition;

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}