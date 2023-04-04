public class EnemyPatrolState : EnemyBaseState
{
    public override void StateEnter()
    {
        // Run & Walk Animation
    }

    public override void StateUpdate()
    {
        Enemy.Move();

        if (Enemy.HasTarget())
        {
            StateManager.SwitchState(StateManager.FollowState);
        }
    }
}
