using System.Collections;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

// need to have separate servicesNPCDialogue script
// should probably just inherit from DialogueController and override whatever
public class DialogueControllerServices : DialogueController
{
    public override void ChooseChoice(int choice)
    {
        //if (choice == 0)
        if (myStory.currentChoices[choice].text == "Shop")
        {
            // start shopping
            Debug.Log("Shop");
        }

        base.ChooseChoice(choice);
    }

    void StartShopping()
    {
    }
}