using UnityEngine;
using States;

public class PlayerStateManager : StateManager
{
    public PlayerController Player;

    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerSearchState SearchState = new PlayerSearchState();
    public PlayerFireState FireState = new PlayerFireState();

    public override void Init()
    {
        MoveState.Player = Player;
        MoveState.StateManager = this;

        SearchState.Player = Player;
        SearchState.StateManager = this;

        FireState.Player = Player;
        FireState.StateManager = this;

        CurrentState = SearchState;

        base.Init();
    }
}
