public class AAAAAAAAAA
{
    /*

    TODO
-------------

    Fix object pool
        SpellFireball not getting reference
        Not activating already instantiated objects, just keeps instantiating new ones. defeats the purpose

    Magic 
    REDO entire system. SpellSO doesn't work like I wanted

        Fix projectile/fireball
    Can't get reference to playerAnimator in SpellFireball. Getting unassigned reference error. Is it because of all the events/listeners?
    There is only one actual instance of SpellFireball in the scene, on the SpellEffects object. 
        Make more spells
        Maybe have a separate script(s) that just holds methods for different spells? Especially
            for unique effects (unlike healing, where I can just call the heal method from the healthManager)

    Input System
        Have action map change to UI in menus, Player during normal gameplay

    Stats
        Add speed stat. Makes the attack timer length shorter
        Flesh out defense, not using it much yet. Try different formulas

    Maybe do skill based "exp". Like Morrowind where you use a skill enough and it levels
        could add an exp int to the statSO class

    fix pause system
        Use new input system to have player and UI controls separate?
            like disable player controls when menus are open, disable UI controls when not?

    build more world

    finish combat system
        fine tune knockback
        Finish Exp/level up system
        Fix death load screen, works as is, but could be better

    make invUI have infinite space
        use scroll bar

    Save system

    Procedural generation of grass/ flowers etc?

    Fix debug buttons
        if statement inside update not working
        but sometimes the event triggers for the buttons don't work
            seems to work sometimes, but not others. even when nothing in the code changes
    Needed to change the variables being changed to public static. No fucking idea why
    Because reference is to player prefab, not instance. Would need to get player reference then set
        up button in code. Not really worth it for a debug button










    */
}