using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        bool Fire(Vector3 targetPosition);
    }
}