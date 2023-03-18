using ObjectPoolings;
using UnityEngine;
using Targets;

namespace Bullets
{
    public class BulletTrigger : MonoBehaviour
    {
        [SerializeField] Bullet bullet;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ITarget>(out ITarget target))
            {
                bullet.Hit(target);
            }

            BulletPool.Instance.Enqueue(bullet);
        }
    }
}
