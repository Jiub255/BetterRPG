public class AAAAAAAAAA
{/* 
   
    TO DO
-------------

    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                PUT
                                ON
                                NO
                                HAY
                                TOS
    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    DO FIRST
        Finish shop menu stuff
            Might have to make new ShopInventorySlot classes/prefabs? 
                So that they can call Buy or Sell from ShopInventoryManager
            Have confirmation popup for buying/selling?
            Have amount popup for stacks of items
            Get shopUI to setup initially
                How to get shopInventorySO reference?
            Fix problems with inv not showing in shopUI
            Fix controls not getting reenabled correctly

        Set up new input system and action maps
            Have a dialogue action map that you switch to instead of disabling swing and stuff
            Make sure only using one action map at a time



    Fix all references to player using onPlayerInstantiated.
        Use onSceneLoaded instead?
    Make a SceneTransitionManager singleton?
        Have:
        ChangeScene(string sceneName, Vector2 startingPosition)
        {
            StartCoroutine(ChangeSceneCO(sceneName, startingPosition);
        }
        Then sceneTransition and playerHealthManager.Die() can both call on it.
        And start/load game from main menu can call on it.
        
    Save system
        FIX:
            Able to move and see player over main menu
                Disable player in main menu and set action map to UI
                Current "fix" is disabling player and melee spriterenderers,
                    then enabling them on scene change
            Make main menu work with UI action map
            Do something about selected buttons, maybe get rid of it? Just use mouse?
                Or make it look better at least and have mouse change currently selected button
                    while hovering over.
        Using "How to make a Save & Load System in Unity | 2022" (Trever Mock)
            youtube video as a base for the save system.
        Save options and key rebindings in PlayerPrefs?
            Or save them each separately in each save slot
            Will playerprefs make options changes universal across all saves?
        Add separate autosave slot for each normal save slot
            Same with a quicksave slot
        Add more stuff to the system now that it works.
            Player facing direction
            Current Spell
            Spell "Inventory" (Once it's set up)
            Objects picked up data (Need to make this Manager)
            Objects broken/ environment changed stuff (Need this manager still too)
            Dialogue stuff (NPCs talked to, choices made, whatever makes sense)
            Merchant inventories
            Quest stuff once it's added to the game
            Plenty more
        Use interface(s) to find all saveable data in the game.
            Put IDataPersistence on all scripts you want to save data from.
                Might need more complicated save/load methods for more complex data.
                Use SerializableDictionary instead of Dictionary.
            Put IDataPersistence on all UIManagers to initalize UI after load.
                Don't need anything in Save, just updateUI in Load.
        Might not need setup scene, maybe main menu scene can do the same.
            Then just start a new game or load into whichever scene you're saved in.
            Player can get initialized in main menu? But scene initialized after scene load?
            Or just initialize everything after scene is loaded, then unload main menu.

    Loot System
        Redo Loot system to use new inventoryManager system, with its list of ItemAmounts.
            Can have LootInventoryManager inherit from InventoryManager and work from there.
            Maybe not. Then you'd need a separate InventorySO for each enemy. 
                This might be easier.
                Could still set it up to be infinite, have stackable items, and let player put stuff
                    back in.
        Fine tune Loot Menu.
            Change UI a bit, clean it up, text sizes etc.
            Make UI fit with invUI.

    Make merchant/shop system.

    Inventory
        Some Items not stacking properly.
            Maybe something to do with items gained from DropLoot vs. ItemPickup?
                But they both raise the same signal which PlayerInventoryManager hears.
        Make items drop not touching each other or player. 
            Maybe have drop method check for player/itempickups and then drop like one unit away.
            Could have it happen in a circular pattern around player so they don't drop too far away.
            Also check for any other colliders, want item to drop in a place that the player can reach.
    
    UI
        Either keep HUD up or make it so you can see current hp/mp and stuff while in inv menu.
        Design better looking UI, make HP/MP bars work/look fitting both in game and in inv menu.
        Change all text components to TextMeshPro, change code accordingly.
            Figure out blurry TMP issue.
        Have sort function.
            Sort by name, type, other ways...
        Fine tune Loot Menu.
            Change UI a bit, clean it up, text sizes etc.
            Make UI fit with invUI.

    Scenes
        For each exterior scene, have one interior scene with all the house/shop/whatever interiors.
            Just have them far enough apart that you can't see the others.
                Creates less scene transition mess?
            Could have separate scenes for special places that need whatever extra stuff in the scene.
        Fix Scene Transition.

    Game Management
        Key rebinding and options menu
            Use "How to use NEW Input System Package! (Unity Tutorial - Keyboard, Mouse, Touch, Gamepad)"
                video on youtube
        Achievements?
        Make a gameplay stats menu
            Keep track of fucking everything
                Number of each enemy killed, total kills
                Gameplay time
                Money collected/spent
                    Substats of how much spent on equipment, items, magic stuff, etc...
                Number of each object broken
                Weird shit
                    Number of times you've pet a cat or dog
        Make a game timer, just to have
            pause timer when in main menu/options?
            Have a separate timer including all in game time? never pauses
        Would it be possible to have a singleton "signal manager"? Like you could call
            any kind of signal to any other script through it?
            Not sure, maybe not. 
            Would the singleton have to keep references to all other scripts to do so?
            And what about multiple instances of a single script?
            Seems difficult if not impossible.

    Dialogue
        Set up merchant system
        
    Magic 
        Move spells to separate object? an "in every scene" prefab?
        Get currentSpell to persist between scenes. Use SO?
        Finish Wind Spell.
        Make more spells.

    Input System
        Set up gamepad, joystick, and other controls.

    Stats
        Add speed stat. Makes the attack timer length shorter.
        Flesh out defense, not using it much yet. Try different formulas.
        Maybe do skill based "exp" like Morrowind where you use a skill enough and it levels.
            Could add an exp int to the statSO class.

    World Building
        Build more world.
        Procedural generation of grass/ flowers etc?

    Combat
        Fine tune knockback.
            Fix player knockback.
                Disable movement/combat while knocking back player.
        Finish Exp/level up system.
        Fix death load screen, works as is, but could be better.

    Other
        Make fishing minigame/steal one from Simple Ass RPG.
            But make it better.




-------------
*/
}