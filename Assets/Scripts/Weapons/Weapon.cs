using ObjectPoolings;
using UnityEngine;
using Bullets;

namespace Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] WeaponData weaponData;
        [SerializeField] Transform firePoint;

        private float lastFireTime;

        private bool CanFire()
        {
            return (Time.time >= (lastFireTime + weaponData.FireRate)) ? true : false;
        }

        public bool Fire(Vector3 targetposition)
        {
            if (!CanFire())
                return false;

            lastFireTime = Time.time;

            LookAt(targetposition);

            Bullet bulet = BulletPool.Instance.Dequeue();

            bulet
                .SetDamage(weaponData.Damage)
                .SetPosition(firePoint.position)
                .SetForward(firePoint.forward)
                .AddForce();

            return true;
        }

        private void LookAt(Vector3 targetPosition)
        {
            targetPosition.y = Mathf.Clamp(targetPosition.y, firePoint.position.y, targetPosition.y);
            transform.LookAt(targetPosition);
        }
    }
}