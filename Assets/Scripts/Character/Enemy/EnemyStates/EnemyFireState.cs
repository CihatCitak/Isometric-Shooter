using UnityEngine;

public class EnemyFireState : EnemyBaseState
{
    public override void StateEnter()
    {
        Enemy.StopMove();
        Enemy.animator.SetBool(CharacterAnimationsStrings.MoveStr, false);

        Enemy.FireStartTime = Time.time;
    }

    public override void StateUpdate()
    {
        bool didFire = Enemy.Fire();

        if (didFire)
            Enemy.animator.SetTrigger(CharacterAnimationsStrings.FireStr);


        if (!Enemy.HasTarget())
        {
            StateManager.SwitchState(StateManager.PatrolState);
        }
        else if (!Enemy.IsFollowDone())
        {
            StateManager.SwitchState(StateManager.FollowState);
        }
    }
}
