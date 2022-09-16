using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
        MasterSingleton.Instance.Canvas.SetActive(true);
        MasterSingleton.Instance.Player.SetActive(true);
    }
}