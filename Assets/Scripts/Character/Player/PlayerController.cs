using UnityEngine;
using Weapons;

public class PlayerController : CharacterController
{
    [SerializeField] InputData input;
    [SerializeField] WeaponHandler weaponHandler;

    private const float AIM_DIFFRENCE = 0.001f;

    public override void Move()
    {
        Look(input.Direction);

        rb.velocity = (input.Direction * characterData.MoveSpeed) + (Vector3.up * rb.velocity.y);
    }

    public bool IsMoving()
    {
        return input.HasInput;
    }

    public override void Fire()
    {
        if (!target.CanTargetable)
        {
            ResetTarget();
            return;
        }

        Vector3 lookDirection = (target.GetTransform().position - transform.position).normalized;
        Look(lookDirection);

        bool canFire = ((modelTransform.forward - lookDirection).sqrMagnitude < AIM_DIFFRENCE) ? true : false;
        if (!canFire)
            return;

        IWeapon weapon = weaponHandler.GetWeapon();
        weapon.Fire();
    }
}
