public class PlayerFireState : PlayerBaseState
{
    public override void StateEnter()
    {
        // Aim animation
        // Fire animation
    }

    public override void StateUpdate()
    {
        bool didFire = Player.Fire();

        if (didFire)
            Player.animator.SetTrigger(CharacterAnimationsStrings.FireStr);

        if (Player.IsMoving())
        {
            StateManager.SwitchState(StateManager.MoveState);
        }
        else if (!Player.HasTarget())
        {
            StateManager.SwitchState(StateManager.SearchState);
        }
    }
}
