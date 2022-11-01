using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeOutCanvas;
    [SerializeField]
    private GameObject fadeInCanvas;
    [SerializeField]
    private float fadeTime = 0.5f;

    [SerializeField]
    private Transform playerTransform;

    // Are these necessary?
    private GameObject fadeInCanvasInstance;
    private GameObject fadeOutCanvasInstance;

    // listens for onPlayerInstantiated? or onSceneLoaded?
    // or just get reference in awake? 
    // Or just assign it in the inspector? Since this and Player are don't destroy on load
    public void GetPlayerReference(Transform transform)
    {
        playerTransform = transform;
    }

    public void ChangeScene(string sceneName, Vector2 startingPosition)
    {
        StartCoroutine(ChangeSceneCO(sceneName, startingPosition));
    }

    IEnumerator ChangeSceneCO(string sceneName, Vector2 startingPosition)
    {
        if (fadeOutCanvas != null)
        {
            if (fadeOutCanvasInstance == null)
            {
                fadeOutCanvasInstance = Instantiate(
                    fadeOutCanvas, Vector3.zero, Quaternion.identity);
                Debug.Log("Instantiated Fade Out Canvas");
                // no need to destroy, gets destroyed by scene unload?
            }
        }

        yield return new WaitForSeconds(fadeTime);

        // Get current spell from player
        // NOT SURE ABOUT THIS
       // Spell currentSpell = collision.GetComponent<CastMagic>().currentSpell;

        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(
            sceneName, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        if (fadeInCanvas != null)
        {
            if (fadeInCanvasInstance == null)
            {
                fadeInCanvasInstance = Instantiate(
                    fadeInCanvas, Vector3.zero, Quaternion.identity);
                Debug.Log("Instantiated Fade In Canvas");
            }
        }

        // In case swing was disabled while you went through scene transition.
        if (!playerTransform.GetComponent<PlayerMelee>().swingActive)
        {
            playerTransform.GetComponent<PlayerMelee>().EnableSwing();
        }

        playerTransform.position = startingPosition;

        yield return new WaitForSeconds(fadeTime);

        Destroy(fadeInCanvasInstance);
        Debug.Log("Destroyed Fade In Canvas");

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}