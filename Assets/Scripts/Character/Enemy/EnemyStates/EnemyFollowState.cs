public class EnemyFollowState : EnemyBaseState
{
    public override void StateEnter()
    {
        Enemy.animator.SetBool(CharacterAnimationsStrings.MoveStr, true);
    }

    public override void StateUpdate()
    {
        Enemy.FollowTarget();

        if (Enemy.IsFollowDone(Enemy.SearchRadius))
        {
            StateManager.SwitchState(StateManager.FireState);
        }
        else
        {
            Enemy.animator.SetFloat(CharacterAnimationsStrings.SpeedStr, Enemy.CalculateMoveAnimationSpeed());
        }
    }
}
