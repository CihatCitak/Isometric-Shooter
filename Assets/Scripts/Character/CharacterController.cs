using UnityEngine;
using Targets;

public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;
    public Rigidbody rb;
    public Transform modelTransform;
    public LayerMask layer;

    protected ITarget target = null;

    private RaycastHit[] raycastHits = new RaycastHit[5];

    public abstract void Move();

    public abstract bool IsMoving();

    public abstract void Fire();

    protected abstract void Look(Vector3 lookDirection);

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
            Gizmos.DrawLine(modelTransform.position, target.GetTransform().position);
        }
    }
#endif
}
