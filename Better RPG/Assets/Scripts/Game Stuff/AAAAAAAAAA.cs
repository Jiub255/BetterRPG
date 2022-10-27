public class AAAAAAAAAA
{/* 
   
    TO DO
-------------

    Maybe get rid of AlwaysOpenScene and just use singletons for different game managers.
        Or have a master singleton again.
        DON'T MAKE PLAYER A SINGLETON!

    Save system
        Get on this soon, to make sure current systems are all saveable.
        Use interface(s) to find all saveable data in the game?
            Will it work with SO's? Can I use their respective managers instead?

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
        Move object pool, put it on an "in every scene" prefab?
    
    Magic 
        Move spells to separate object? an "in every scene" prefab?
        Get currentSpell to persist between scenes.
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
*/}