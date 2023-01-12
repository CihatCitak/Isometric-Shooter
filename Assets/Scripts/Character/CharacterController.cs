using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    public CharacterData characterData;
    public Rigidbody rb;
    public Transform modelTransform;
    public LayerMask layer;

    private CharacterController target = null;

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
            target = hit.transform.GetComponent<CharacterController>();

            Debug.Log(hit.transform.name);
        }
        else
        {
            target = null;
        }
    }
}
