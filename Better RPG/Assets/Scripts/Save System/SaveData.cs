using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Should this be static? Would it need a constructor? Not sure about this stuff.
public class SaveData // NOT MONOBEHAVIOUR? 
{

    // Want to collect all data that I want to save here before actually saving it. 
    // Keep it all in one file this way.
    // Not sure how to handle all the different SO's/Lists of custom classes that I'll want to save.
    // Maybe make this class an SO and then just save it?
    // Should I keep it updated during gameplay?

    // DATA - PUT ALL DATA TO BE SAVED HERE (INCLUDE LISTS OF CUSTOM CLASSES)



    // METHODS. IS STATIC NEEDED?

    public SaveData()
    {

    }

    // GET VALUES METHOD
    public void GetValues(SaveData saveData)
    {
        // copy values from gameobjects/SOs/whatever to the DATA variables here.

        // Use interface(s) (ISaveable?) to find all saveable data?
    }

    public void GiveValues(SaveData saveData)
    {
        // copy values from the DATA variables here to the various gameobjects/SOs/whatever.
    }

    // PUT IN SAVEMANAGER?

}