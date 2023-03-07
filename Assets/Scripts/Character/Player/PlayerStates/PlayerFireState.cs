using UnityEngine;
using States;

public class PlayerFireState : IState
{
    public PlayerController Player;
    public PlayerStateManager StateManager;
    public void StateEnter()
    {
        // Aim animation
        // Fire animation
    }

    public void StateUpdate()
    {
        Player.Fire();

        if (Player.IsMoving())
        {
            StateManager.SwitchState(StateManager.MoveState);
        }
    }
}
