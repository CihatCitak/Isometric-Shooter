using UnityEngine;

public class PlayerFireState : PlayerBaseState
{
    public override void StateEnter()
    {
        Player.FireStartTime = Time.time;
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
