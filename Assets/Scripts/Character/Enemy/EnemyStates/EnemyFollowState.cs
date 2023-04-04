public class EnemyFollowState : EnemyBaseState
{
    public override void StateEnter()
    {
    }

    public override void StateUpdate()
    {
        Enemy.FollowTarget();
    }
}
