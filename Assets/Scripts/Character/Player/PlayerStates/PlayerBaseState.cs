
using States;

public abstract class PlayerBaseState : IState
{
    public PlayerController Player;
    public PlayerStateManager StateManager;

    public abstract void StateEnter();

    public abstract void StateUpdate();
}
