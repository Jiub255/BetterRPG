using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameFromAlwaysOpen : MonoBehaviour
{
    public string startingScene;

    public Vector2 startingPosition;

    public GameEventSceneVector3 onSceneChanged;

    private void Start()
    {
        StartCoroutine(AdditivelyLoadStartingScene());
    }

    IEnumerator AdditivelyLoadStartingScene()
    {
        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(startingScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(startingScene));

        // Send signal to ScenePrefabInstantiator, it instantiates the prefabs and moves player to starting position
        onSceneChanged.Raise(SceneManager.GetSceneByName(startingScene), startingPosition);

        // Don't unload current scene
    }
}