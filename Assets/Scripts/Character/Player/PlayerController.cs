using UnityEngine;

public class PlayerController : CharacterController
{
    public InputData input;

    public override void Move()
    {
        Look(input.Direction);

        rb.velocity = (input.Direction * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
    }

    public bool IsMoving()
    {
        return input.HasInput;
    }

    public override void Dead()
    {
        animator.SetTrigger(CharacterAnimationsStrings.DeadStr);
    }
}
