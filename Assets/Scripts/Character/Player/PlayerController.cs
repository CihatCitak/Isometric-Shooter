using UnityEngine;

public class PlayerController : CharacterController
{
    [SerializeField] InputData input;

    protected override void Look(Vector3 lookDirection)
    {
        modelTransform.forward = Vector3.Lerp(modelTransform.forward, lookDirection, Time.fixedDeltaTime * characterData.LookSpeed);
    }

    public override void Move()
    {
        Look(input.Direction);

        rb.velocity = (input.Direction * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
    }

    public override bool IsMoving()
    {
        return input.HasInput;
    }
}
