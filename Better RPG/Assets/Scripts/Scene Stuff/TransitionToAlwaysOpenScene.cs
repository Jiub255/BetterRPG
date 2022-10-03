using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToAlwaysOpenScene : MonoBehaviour
{
    public string alwaysOpenScene = "AlwaysOpen";

    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(alwaysOpenScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(alwaysOpenScene));

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}