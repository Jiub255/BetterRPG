using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField]
    private string profileID = "";

    [Header("Content")]
    [SerializeField]
    private GameObject noDataContent;
    [SerializeField]
    private GameObject hasDataContent;
    [SerializeField]
    private TextMeshProUGUI percentageCompleteText;
    [SerializeField]
    private TextMeshProUGUI currentHealthText;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        // There's no data for this profileID
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        // There is data for this profileID
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            percentageCompleteText.text = data.GetPercentageComplete().ToString() + "% Complete";
            currentHealthText.text = "Current Health: " + data.currentHealth.ToString();
        }
    }

    public string GetProfileID()
    {
        return profileID;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}