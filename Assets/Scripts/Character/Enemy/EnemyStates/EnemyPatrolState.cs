public class EnemyPatrolState : EnemyBaseState
{
    public override void StateEnter()
    {
        Enemy.animator.SetBool(CharacterAnimationsStrings.MoveStr, true);
    }

    public override void StateUpdate()
    {
        Enemy.Move();

        if (Enemy.HasTarget())
        {
            StateManager.SwitchState(StateManager.FollowState);
        }
        else
        {
            Enemy.animator.SetFloat(CharacterAnimationsStrings.SpeedStr, Enemy.CalculateMoveAnimationSpeed());
        }
    }
}
