using UnityEngine;
using Targets;
using Weapons;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Transform modelTransform;
    [SerializeField] LayerMask layer;
    [SerializeField] WeaponHandler weaponHandler;
    public Animator animator;

    private const float AIM_DIFFRENCE = 0.001f;

    protected ITarget target = null;
    protected Vector3 TargetPosition => target.GetTransform().position;

    private float fireStartTime = 0f;
    public float FireStartTime { get => fireStartTime; set => fireStartTime = value; }

    private RaycastHit[] raycastHits = new RaycastHit[5];

    public abstract void Move();

    public abstract void Dead();

    public float GetAnimationTransitionDuration()
    {
        return animator.GetAnimatorTransitionInfo(0).duration;
    }

    public bool IsAimAnimDone()
    {
        return (FireStartTime + GetAnimationTransitionDuration()) < Time.time;
    }

    public virtual bool Fire()
    {
        if (!target.CanTargetable)
        {
            ResetTarget();
            return false;
        }

        Vector3 lookDirection = (TargetPosition - transform.position).normalized;
        Look(lookDirection);

        bool canFire = ((modelTransform.forward - lookDirection).sqrMagnitude < AIM_DIFFRENCE) ? true : false;
        if (!canFire)
            return false;

        if (!IsAimAnimDone())
            return false;

        IWeapon weapon = weaponHandler.GetWeapon();
        return weapon.Fire(target.GetTransform().position);
    }

    protected virtual void Look(Vector3 lookDirection)
    {
        lookDirection.y = modelTransform.forward.y;
        modelTransform.forward = Vector3.Lerp(modelTransform.forward, lookDirection, Time.fixedDeltaTime * characterData.LookSpeed);
    }

    public virtual void Search()
    {
        int hitCount = Physics.SphereCastNonAlloc(modelTransform.position, characterData.SearchRadius, Vector3.up, raycastHits, Mathf.Infinity, layer);

        if (hitCount <= 0)
        {
            target = null;
            return;
        }

        Transform nearestTransform = FindNearestTransform(hitCount);
        target = TargetManager.FindTargetFromTransform(nearestTransform);
    }

    public virtual bool HasTarget()
    {
        return (target != null) ? true : false;
    }

    public virtual void ResetTarget()
    {
        target = null;
    }

    private Transform FindNearestTransform(int hitCount)
    {
        Transform nearestTransform = raycastHits[0].transform;

        for (int i = 1; i < hitCount; i++)
        {
            Transform nextTransform = raycastHits[i].transform;

            float nearestTargetDistance = (modelTransform.position - nearestTransform.position).sqrMagnitude;
            float nextTargetDistance = (modelTransform.position - nextTransform.position).sqrMagnitude;

            if (nextTargetDistance < nearestTargetDistance)
            {
                nearestTransform = nextTransform;
            }
        }

        return nearestTransform;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (target != null)
            Gizmos.color = new Color(0f, 1f, 0f, 0.15f);
        else
            Gizmos.color = new Color(1f, 0f, 0f, 0.15f);

        Gizmos.DrawSphere(modelTransform.position, characterData.SearchRadius);

        if (target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(modelTransform.position, TargetPosition);
        }
    }
#endif
}
