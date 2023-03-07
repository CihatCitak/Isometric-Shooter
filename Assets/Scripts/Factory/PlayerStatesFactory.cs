using States;

namespace Factory
{
    public class PlayerStatesFactory
    {
        public static IState CreatePlayerState(PlayerStates state)
        {
            switch (state)
            {
                case PlayerStates.Move:
                    return new PlayerMoveState();

                case PlayerStates.Search:
                    return new PlayerSearchState();

                case PlayerStates.Fire:
                    return new PlayerFireState();

                default:
                    return null;
            }
        }
    }
}

public enum PlayerStates
{
    Move,
    Search,
    Fire
}

