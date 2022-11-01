using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameFromSetupScene : MonoBehaviour
{
    public string startingScene;

    public Vector2 startingPosition;

    public GameEventVector3 onGameStarted;

    private Transform playerTransform;

    private void Awake()
    {
       // Debug.Break();
    }

    private void Start()
    {
        StartCoroutine(AdditivelyLoadStartingScene());
    }

    // listens for onPlayerInstantiated
    public void GetPlayerReference(Transform transform)
    {
        playerTransform = transform;
        
        Debug.Log("Got player reference: " + playerTransform.name);
    }

    IEnumerator AdditivelyLoadStartingScene()
    {
        yield return new WaitForEndOfFrame();

        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(startingScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        //Debug.Break();

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(startingScene));

        playerTransform.position = startingPosition;

        // Unload current scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}