public class AAAAAAAAAA
{
    /*

    TODO
-------------

    Fix loot system
        LootUI disables after emptying a dropLoot even if there are other in range
            Make it switch to next available one instead
        Redo Loot system to use new inventoryManager system, with its list of ItemAmounts
            Can have LootInventoryManager inherit from InventoryManager and work from there

    Make merchant system

    Fix Inv/invUI issues
    Make items drop not touching each other or player. 
        maybe have drop method check for player/itempickups and then drop like one unit away
        could have it happen in a circular pattern around player so they don't drop too far away
        also check for any other colliders, want item to drop in a place that the player can reach
    Have sort function
        sort by name, type, other ways
   
    Fine tune Loot Menu 
        change UI a bit, clean it up, text sizes etc
        make UI fit with invUI
    
    UI
        Either keep HUD up or make it so you can see current hp/mp and stuff while in inv menu
        Design better looking UI, make HP/MP bars work/look fitting both in game and in inv menu
        Change all text components to TextMeshPro, change code accordingly
            Figure out blurry TMP issue

    For each exterior scene, have one interior scene with all the house/shop/whatever interiors
        just have them far enough apart that you can't see the others
        less scene transition mess
        could have separate interior scenes for special places that need whatever extra stuff in the scene

    Fix Scene Transition

    Move object pool, put it on an "in every scene" prefab?
    
    Magic 
        Move spells to separate object? an "in every scene" prefab?
        Get currentSpell to persist between scenes
        Finish Wind Spell
        Make more spells

    Input System
        Set up gamepad, joystick, and other controls

    Stats
        Add speed stat. Makes the attack timer length shorter
        Flesh out defense, not using it much yet. Try different formulas

    Maybe do skill based "exp". Like Morrowind where you use a skill enough and it levels
        could add an exp int to the statSO class

    Build more world

    Finish combat system
        fine tune knockback
            fix player knockback
                disable movement/combat while knockingback player
        Finish Exp/level up system
        Fix death load screen, works as is, but could be better

    Save system

    Procedural generation of grass/ flowers etc?

    Fishing Minigame



    */
}