using UnityEngine.AI;
using UnityEngine;

public class EnemyController : CharacterController
{
    [Header("Patrol")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Patrol patrol;

    private Vector3 movePosition = Vector3.up * -9999f;
    private const float MIN_DESIRED_VELOCITY = 1f;

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

    public bool IsFollowDone()
    {
        return (TargetPosition - transform.position).sqrMagnitude <
            characterData.SearchRadius * characterData.SearchRadius;
    }

    public override void Dead()
    {
        Destroy(gameObject);
    }
}
