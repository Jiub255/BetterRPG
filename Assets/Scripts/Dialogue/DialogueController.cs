using System.Collections;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;

    [SerializeField] GameObject dialoguePrefab;
    [SerializeField] GameObject responsePrefab;

    [SerializeField] TextAssetSO dialogueValue;

    public Story myStory;

    [SerializeField] GameObject dialogueContent;
    [SerializeField] GameObject responseContent;
    [SerializeField] ScrollRect dialogueScroll;

    [SerializeField] GameEvent onDialogueOver;

    public void EnableCanvas()
    {
        dialoguePanel.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if (dialogueValue.value)
        {
            myStory = new Story(dialogueValue.value.text);
        }
        else
        {
            Debug.Log("dialogueValue.value == null");
        }
    }

    public void RefreshView()
    {
        while (myStory.canContinue)
        {
            MakeNewDialog(myStory.Continue());
        }

        if (myStory.currentChoices.Count > 0)
        {
            MakeNewChoices();
        }
        else
        {
            dialoguePanel.SetActive(false);
            onDialogueOver.Raise();
            Debug.Log("Dialogue over signal sent");
        }

        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo()
    {
        yield return null;
        dialogueScroll.verticalNormalizedPosition = 0f;
    }

    void MakeNewDialog(string newDialog)
    {
        DialogueObject newDialogObject = Instantiate(dialoguePrefab,
            dialogueContent.transform).GetComponent<DialogueObject>();

        newDialogObject.Setup(newDialog);
    }

    void MakeNewResponse(string newDialog, int choiceValue)
    {
        ResponseObject newResponseObject = Instantiate(responsePrefab,
            responseContent.transform).GetComponent<ResponseObject>();

        newResponseObject.Setup(newDialog, choiceValue);

        Button responseButton = newResponseObject.gameObject.GetComponent<Button>();

        if (responseButton)
        {
            responseButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void MakeNewChoices()
    {
        for (int i = 0; i < responseContent.transform.childCount; i++)
        {
            Destroy(responseContent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myStory.currentChoices[i].text, i);
        }
    }

    public virtual void ChooseChoice(int choice)
    {
        myStory.ChooseChoiceIndex(choice);

        RefreshView();
    }
}