using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string sceneToLoad;

    [SerializeField] Vector2 startingPosition;

    [SerializeField] GameEventSceneVector3 onSceneChanged;

    [SerializeField] GameObject fadeOutCanvas;
    [SerializeField] GameObject fadeInCanvas;
    [SerializeField] float fadeTime = 0.5f;
    GameObject fadeInCanvasInstance;
    GameObject fadeOutCanvasInstance;

    private void Awake()
    {
/*        if (fadeInCanvas != null)
        {
            if(fadeInCanvasInstance == null)
            {
                fadeInCanvasInstance = Instantiate(fadeInCanvas,Vector3.zero, Quaternion.identity);
                Debug.Log("Instantiated Fade In Canvas");
            }
        }

        Destroy(fadeInCanvasInstance, fadeTime);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene(collision));
        }
    }

    IEnumerator ChangeScene(Collider2D collision)
    {
        if (fadeOutCanvas != null)
        {
            if (fadeOutCanvasInstance == null)
            {
                fadeOutCanvasInstance = Instantiate(fadeOutCanvas, Vector3.zero, Quaternion.identity);
                Debug.Log("Instantiated Fade Out Canvas");
                // no need to destroy, gets destroyed by scene unload?
            }
        }

        yield return new WaitForSeconds(fadeTime);

        // Get current spell from player
        // NOT SURE ABOUT THIS
        Spell currentSpell = collision.GetComponent<CastMagic>().currentSpell;

        // Set scene variable to unload it at the end of the coroutine
        Scene currentScene = SceneManager.GetActiveScene();

        // Load new scene in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        //Destroy(fadeOutCanvasInstance);
        //Debug.Log("Destroyed Fade Out Canvas");

        // Set newly loaded scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));


        if (fadeInCanvas != null)
        {
            if (fadeInCanvasInstance == null)
            {
                fadeInCanvasInstance = Instantiate(fadeInCanvas, Vector3.zero, Quaternion.identity);
                Debug.Log("Instantiated Fade In Canvas");
            }
        }

        yield return new WaitForSeconds(fadeTime);

        // Send signal to ScenePrefabInstantiator, it instantiates the prefabs and moves player to starting position
        onSceneChanged.Raise(SceneManager.GetSceneByName(sceneToLoad), startingPosition);



        Destroy(fadeInCanvasInstance);
        Debug.Log("Destroyed Fade In Canvas");

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}