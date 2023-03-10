using UnityEngine;
using Bullets;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Weapon Data", fileName = "Weapon Data")]
    public class WeaponData : MonoBehaviour
    {
        [SerializeField] Bullet bullet;
        [SerializeField] int damage;
        [SerializeField] float fireRate;
        [SerializeField] int magazine;

        public Bullet Bullet { get => bullet; }
        public int Damage { get => damage; }
        public float FireRate { get => fireRate; }
        public int Magazine { get => magazine; }
    }
}
