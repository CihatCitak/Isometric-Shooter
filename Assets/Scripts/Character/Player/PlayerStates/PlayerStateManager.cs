using Factory;
using States;

public class PlayerStateManager : StateManager
{
    public PlayerController Player;

    public PlayerMoveState MoveState;
    public PlayerSearchState SearchState;
    public PlayerFireState FireState;

    public override void Init()
    {
        MoveState = (PlayerMoveState)PlayerStatesFactory.CreatePlayerState(PlayerStates.Move);
        MoveState.Player = Player;
        MoveState.StateManager = this;

        SearchState = (PlayerSearchState)PlayerStatesFactory.CreatePlayerState(PlayerStates.Search);
        SearchState.Player = Player;
        SearchState.StateManager = this;

        FireState = (PlayerFireState)PlayerStatesFactory.CreatePlayerState(PlayerStates.Fire);
        FireState.Player = Player;
        FireState.StateManager = this;

        CurrentState = SearchState;

        base.Init();
    }
}
