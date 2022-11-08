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

    public void ChangeScene(string sceneName, Vector2 startingPosition, bool isLoading)
    {
        StartCoroutine(ChangeSceneCO(sceneName, startingPosition, isLoading));
    }

    IEnumerator ChangeSceneCO(string sceneName, Vector2 startingPosition, bool isLoading)
    {
        // Instantiate fade out canvas
        Instantiate(fadeOutCanvas, Vector3.zero, Quaternion.identity);
        Debug.Log("Instantiated Fade Out Canvas");
        // no need to destroy, gets destroyed by scene unload

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

        // Instantiate fade in canvas
        GameObject fadeInCanvasInstance = Instantiate(
            fadeInCanvas, Vector3.zero, Quaternion.identity);
        Debug.Log("Instantiated Fade In Canvas: " + fadeInCanvasInstance.name);

        // Unload previous scene here so it doesn't block fade in canvas
        // and so you don't see both scenes 
        SceneManager.UnloadSceneAsync(currentScene);

        // Make player visible if not (when coming from start menu)
        if (!playerTransform.GetComponent<SpriteRenderer>().enabled)
        {
            playerTransform.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!playerTransform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
        {
            playerTransform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }

        // In case swing was disabled while you went through scene transition.
        if (!playerTransform.GetComponent<PlayerMelee>().swingActive)
        {
            playerTransform.GetComponent<PlayerMelee>().EnableSwing();
        }

        // This is messing/overriding loading and setting loaded player position.
        // Use an isLoading bool check here.
        if (!isLoading)
        {
            playerTransform.position = startingPosition;
        }

        yield return new WaitForSeconds(fadeTime);

        // Set HUD to active
        MasterSingleton.Instance.Canvas.transform.GetChild(5).gameObject.SetActive(true);

        Destroy(fadeInCanvasInstance);
        Debug.Log("Destroyed Fade In Canvas");
    }
}