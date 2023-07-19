using UnityEngine.AI;
using UnityEngine;
using LevelManagement;

public class EnemyController : CharacterController
{
    [Header("Patrol")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Patrol patrol;

    private Vector3 movePosition = Vector3.up * -9999f;
    private const float MIN_DESIRED_VELOCITY = 1f;

    public float FireRadius => characterData.FireRadius;
    public float SearchRadius => characterData.SearchRadius;

    private void Start()
    {
        agent.speed = characterData.MoveSpeed;
    }

    public override void Move()
    {
        Vector3 LookDirection = (movePosition - transform.position).normalized;
        Look(LookDirection);

        if (agent.desiredVelocity.sqrMagnitude <= MIN_DESIRED_VELOCITY)
        {
            movePosition = patrol.GetPatrolPosition();
            agent.SetDestination(movePosition);
        }

        Search();
    }

    public void StopMove()
    {
        agent.SetDestination(transform.position);
    }

    public void FollowTarget()
    {
        if (!target.CanTargetable)
            return;

        Vector3 LookDirection = (TargetPosition - transform.position).normalized;
        Look(LookDirection);

        agent.SetDestination(TargetPosition);
    }

    public bool IsFollowDone(float radius)
    {
        return ((TargetPosition - transform.position).sqrMagnitude) < (radius * radius);
    }

    public float CalculateMoveAnimationSpeed()
    {
        return Mathf.Abs(agent.desiredVelocity.z / characterData.MoveSpeed);
    }

    public override void Dead()
    {
        animator.SetTrigger(CharacterAnimationsStrings.DeadStr);

        LevelEnd.OnEnemyDead?.Invoke();
    }
}
