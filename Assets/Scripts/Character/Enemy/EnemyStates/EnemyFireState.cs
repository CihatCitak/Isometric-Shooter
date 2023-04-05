public class EnemyFireState : EnemyBaseState
{
    public override void StateEnter()
    {
        Enemy.StopMove();
    }

    public override void StateUpdate()
    {
        Enemy.Fire();

        if (!Enemy.HasTarget())
        {
            StateManager.SwitchState(StateManager.PatrolState);
        }
        else if (!Enemy.IsFollowDone())
        {
            StateManager.SwitchState(StateManager.FollowState);
        }
    }
}
