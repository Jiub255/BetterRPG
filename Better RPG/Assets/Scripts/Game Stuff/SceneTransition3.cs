using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition3 : MonoBehaviour
{
    public string sceneToLoad;

    public Vector2 startingPosition;

    public GameEventSceneVector3 onSceneChanged;

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

        // Send signal to ScenePrefabInstantiator, it instantiates the prefabs and moves player to starting position
        onSceneChanged.Raise(SceneManager.GetSceneByName(sceneToLoad), startingPosition);

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
