using TMPro;
using UnityEngine;

public class SignUI : MonoBehaviour
{
    [SerializeField] GameObject signPanel;
    [SerializeField] TextMeshProUGUI signText;

    private void OnEnable()
    {
        Sign.signalEventString += UpdateDialog;
    }

    private void OnDisable()
    {
        Sign.signalEventString -= UpdateDialog;
    }

    public void UpdateDialog(string text)
    {
        signText.text = text;

        signPanel.SetActive(!signPanel.activeInHierarchy);

        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }

        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}