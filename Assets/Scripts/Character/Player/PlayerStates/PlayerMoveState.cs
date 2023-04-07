using States;
using UnityEngine;

public class PlayerMoveState : IState
{
    public PlayerController Player;
    public PlayerStateManager StateManager;

    public void StateEnter()
    {
        Player.animator.SetBool(CharacterAnimationsStrings.MoveStr, true);

        Player.ResetTarget();
    }

    public void StateUpdate()
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
