using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToFirstScene : MonoBehaviour
{
    // Might not need the PreLoadScene at all since we're instantiating prefabs now

    public string firstScene;

    public Vector2 startingPosition;

    [Header("Don't put player prefab in here")]
    public List<GameObject> thingsToKeepInEveryScene = new List<GameObject>();

    [Header("Put it in here")]
    public GameObject player;

    public GameEventTransform onPlayerInstantiated;

    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(firstScene));

        // Instantiate all the menus, camera, player, etc.
        foreach (GameObject thing in thingsToKeepInEveryScene)
        {
            Instantiate(thing);
            Debug.Log("Instantiated " + thing.name);
        }

        Transform playerTransform = Instantiate(player).transform;
        Debug.Log("Instantiated " + playerTransform.gameObject.name);

        // Send signal for RoomTransition scripts to get reference to player,
        // now that its instantiated in the scene
        onPlayerInstantiated.Raise(playerTransform);

        // Or just MoveGameObjectToScene, in a for loop over a list of gameobjects?
        /*        foreach (GameObject gameObject in thingsToKeepInNextScene)
                {
                    SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(sceneToLoad));
                    //SceneManager.MoveGameObjectToScene(gameObject, scene2Load);
                }*/

        // Move player to starting position
        playerTransform.position = startingPosition;

        // Unload previous scene
       
        /*AsyncOperation unloadOperation = */SceneManager.UnloadSceneAsync(currentScene);

/*        while (!unloadOperation.isDone)
        {
            yield return null;
        }*/
    }
}