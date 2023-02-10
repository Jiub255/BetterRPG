using UnityEngine;

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
            StartShopping();
        }

        // This part closes dialogue panel
        base.ChooseChoice(choice);
    }

    private void StartShopping()
    {
        Debug.Log("Started shopping");

        // Already have player disabled
        // and hopefully using UI action map
        // So just need to open shop menu
        // and have closing shop menu reactivate player/controls

        MasterSingleton.Instance.Canvas.GetComponent<ShopUI>().OpenShopUI();
    }
}