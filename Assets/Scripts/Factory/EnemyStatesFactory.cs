using States;

namespace Factory
{
    public class EnemyStatesFactory
    {
        public static IState CreateEnemyState(EnemyStates state)
        {
            switch (state)
            {
                case EnemyStates.Patrol:
                    return new EnemyPatrolState();

                case EnemyStates.Follow:
                    return new EnemyFollowState();

                case EnemyStates.Fire:
                    return new EnemyFireState();

                default:
                    return null;
            }
        }
    }
}

public enum EnemyStates
{
    Patrol,
    Follow,
    Fire
}
