public class PlayerSearchState : PlayerBaseState
{
    public override void StateEnter()
    {
        Player.animator.SetBool(CharacterAnimationsStrings.MoveStr, false);
    }

    public override void StateUpdate()
    {
        Player.Search();

        if (Player.IsMoving())
        {
            StateManager.SwitchState(StateManager.MoveState);
        }
        else if (Player.HasTarget())
        {
            StateManager.SwitchState(StateManager.FireState);
        }
    }
}
