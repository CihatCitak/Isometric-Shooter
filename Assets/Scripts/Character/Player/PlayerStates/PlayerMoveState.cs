public class PlayerMoveState : PlayerBaseState
{
    public override void StateEnter()
    {
        Player.animator.SetBool(CharacterAnimationsStrings.MoveStr, true);

        Player.ResetTarget();
    }

    public override void StateUpdate()
    {
        Player.Move();

        if (!Player.IsMoving())
        {
            StateManager.SwitchState(StateManager.SearchState);
        }
        else
        {
            Player.animator.SetFloat(CharacterAnimationsStrings.SpeedStr, Player.input.Direction.sqrMagnitude);
        }
    }
}
