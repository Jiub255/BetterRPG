using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameEventSceneVector3 onSceneChanged;

    public StringSO sceneNameSO;

    // listen for onDead then call this
    public void ReloadScene(Scene currentScene, Vector3 positionAtDeath)
    {
        StartCoroutine(ChangeScene(currentScene, positionAtDeath));
    }

    IEnumerator ChangeScene(Scene currentScene, Vector3 positionAtDeath)
    {
        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(currentScene.buildIndex, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(/*currentScene*/ SceneManager.GetSceneByName(sceneNameSO.String));

        // Getting stuck here
        //Debug.Log("Scene to load: " + currentScene.name + "Position at death: " + positionAtDeath.ToString());

        // Send signal to ScenePrefabInstantiator, it instantiates the prefabs and moves player to starting position
        onSceneChanged.Raise(/*currentScene*/ SceneManager.GetSceneByName(sceneNameSO.String), positionAtDeath);

        // Unload loading scene
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LoadingScene"));
    }
}