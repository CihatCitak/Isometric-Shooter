public class EnemyFollowState : EnemyBaseState
{
    public override void StateEnter()
    {
    }

    public override void StateUpdate()
    {
        Enemy.FollowTarget();

        if (Enemy.IsFollowDone())
        {
            StateManager.SwitchState(StateManager.FireState);
        }
    }
}
