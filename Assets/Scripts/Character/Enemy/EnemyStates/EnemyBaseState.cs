using States;

public abstract class EnemyBaseState : IState
{
    public EnemyController Enemy;
    public EnemyStateManager StateManager;

    public abstract void StateEnter();
    public abstract void StateUpdate();
}
