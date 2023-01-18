using UnityEngine;
using Targets;

public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;
    public Rigidbody rb;
    public Transform modelTransform;
    public LayerMask layer;

    private ITarget target = null;

    private RaycastHit[] raycastHits = new RaycastHit[5];

    private void FixedUpdate()
    {
        Move();
        Look();
        Search();
    }

    public abstract void Move();

    public abstract void Look();

    public virtual void Search()
    {
        int hitCount = Physics.SphereCastNonAlloc(modelTransform.position, characterData.SearchRadius, Vector3.up, raycastHits, Mathf.Infinity, layer);

        if (hitCount > 0)
        {
            RaycastHit hit = raycastHits[0];
            target = TargetManager.FindTargetFromTransform(raycastHits[0].transform);

            Debug.Log(hit.transform.name);
        }
        else
        {
            target = null;
        }
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
