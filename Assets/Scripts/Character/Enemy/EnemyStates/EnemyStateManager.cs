using Factory;
using States;

public class EnemyStateManager : StateManager
{
    public EnemyController Enemy;

    public EnemyPatrolState PatrolState;
    public EnemyFollowState FollowState;
    public EnemyFireState FireState;

    public override void Init()
    {
        PatrolState = (EnemyPatrolState)EnemyStatesFactory.CreateEnemyState(EnemyStates.Patrol);
        PatrolState.Enemy = Enemy;
        PatrolState.StateManager = this;

        FollowState = (EnemyFollowState)EnemyStatesFactory.CreateEnemyState(EnemyStates.Patrol);
        FollowState.Enemy = Enemy;
        FollowState.StateManager = this;

        FireState = (EnemyFireState)EnemyStatesFactory.CreateEnemyState(EnemyStates.Patrol);
        FireState.Enemy = Enemy;
        FireState.StateManager = this;

        CurrentState = PatrolState;

        base.Init();
    }
}
