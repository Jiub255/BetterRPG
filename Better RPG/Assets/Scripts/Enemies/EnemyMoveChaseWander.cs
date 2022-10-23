using UnityEngine;

public class EnemyMoveChaseWander : EnemyMovementTrigger
{
    public override void PlayerNearAction()
    {
        base.PlayerNearAction();

        Vector2 movementVector = Vector2.MoveTowards(transform.position, target.position,
            moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(movementVector);
    }

    public override void PlayerFarAction()
    {
        base.PlayerFarAction();

        // some random wandering stuff
    }
}